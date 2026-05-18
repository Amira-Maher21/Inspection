using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequests;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionRequests
{
    public class InspectionDashboardQueryRepository
        : QueryRepositoryBase<InspectionRequest>, IInspectionDashboardQueryRepository
    {
        public InspectionDashboardQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<InspectionDashboardDto>>
     GetDashboardAsync(InspectionDashboardFilterDto filter)
        {
            try
            {
                #region Base Query

                var query = _dbSet
                   .Include(x => x.Customers)
                   .Include(x => x.CustomerProjects)
                   .Include(x => x.CustomerLocations)
                   .AsQueryable();

                #endregion


                #region Dynamic Filters

                if (filter.CustomerId.HasValue)
                    query = query.Where(x => x.CustomerId == filter.CustomerId.Value);

                if (filter.ProjectId.HasValue)
                    query = query.Where(x => x.CustomerProjectId == filter.ProjectId.Value);

                //if (filter.QuotationIssued.HasValue)
                //    query = query.Where(x =>
                //        x.DocumentStatus == InspectionDocumentStatus.QuotationIssued);

                if (filter.Status.HasValue)
                    query = query.Where(x => x.DocumentStatus == filter.Status);

                if (filter.FromDate.HasValue)
                {
                    if (filter.UseRequestedInspectionDate)
                        query = query.Where(x =>
                            x.RequestedInspectionDate >= filter.FromDate.Value);
                    else
                        query = query.Where(x =>
                            x.RequestDate >= filter.FromDate.Value);
                }

                if (filter.ToDate.HasValue)
                {
                    if (filter.UseRequestedInspectionDate)
                        query = query.Where(x =>
                            x.RequestedInspectionDate <= filter.ToDate.Value);
                    else
                        query = query.Where(x =>
                            x.RequestDate <= filter.ToDate.Value);
                }

                #endregion


                #region KPI - Main Counters

                // Total Requests
                var totalRequests = await query.CountAsync();

                // Requests In Progress
                var inProgress = await query
                    .Where(x => x.DocumentStatus == InspectionDocumentStatus.InProgress)
                    .CountAsync();

                // Cancelled or Closed Requests
                var cancelledOrClosed = await query
                    .Where(x =>
                        x.DocumentStatus == InspectionDocumentStatus.Closed ||
                        x.DocumentStatus == InspectionDocumentStatus.Cancelled)
                    .CountAsync();

                // Scheduled Requests
                var scheduledRequests = await query
                    .Where(x => x.DocumentStatus == InspectionDocumentStatus.Scheduled)
                    .CountAsync();

                // Completed Requests (considered as Closed)
                var completedRequests = await query
                    .Where(x => x.DocumentStatus == InspectionDocumentStatus.Closed)
                    .CountAsync();

                #endregion


                #region KPI - Requests By Status

                // Group requests by document status
                var requestsByStatus = await query
                    .GroupBy(x => x.DocumentStatus)
                    .Select(g => new RequestsByStatusDto
                    {
                        Status = g.Key.ToString(),
                        Count = g.Count()
                    })
                    .ToListAsync();

                #endregion


                #region KPI - Latest Requests (Top 10)

                var latestRequests = await query
                    .OrderByDescending(x => x.RequestDate)
                    .Take(10)
                    .Select(x => new LatestInspectionRequestDto
                    {
                        RequestNumber = x.RequestNumber,
                        CustomerName = x.Customers.Name,

                        ProjectName = x.CustomerProjects != null
                            ? x.CustomerProjects.ProjectName
                            : null,

                        LocationName = x.CustomerLocations != null
                            ? x.CustomerLocations.Location
                            : null,

                        Status = x.DocumentStatus.ToString(),
                        RequestDate = x.RequestDate,
                        RequestedInspectionDate = x.RequestedInspectionDate,

                        QuotationIssued =
                            x.DocumentStatus == InspectionDocumentStatus.QuotationIssued
                    })
                    .ToListAsync();

                #endregion


                #region KPI - Requests Per Customer + Repeat %

                var requestsPerCustomer = await query
                    .GroupBy(x => x.CustomerId)
                    .Select(g => new RequestsPerCustomerDto
                    {
                        CustomerId = g.Key,
                        CustomerName = g.First().Customers.Name,
                        Count = g.Count()
                    })
                    .ToListAsync();

                var totalCustomers = requestsPerCustomer.Count;

                var repeatCustomersCount = requestsPerCustomer
                    .Count(x => x.Count > 1);

                double repeatCustomerPercentage = 0;

                if (totalCustomers > 0)
                    repeatCustomerPercentage =
                        (double)repeatCustomersCount / totalCustomers * 100;

                // Round to 2 decimal places to avoid warning or long decimals
                repeatCustomerPercentage = Math.Round(repeatCustomerPercentage, 2);

                #endregion


                #region KPI - Quotation Metrics

                var quotationIssued = await query
                    .CountAsync(x =>
                        x.DocumentStatus == InspectionDocumentStatus.QuotationIssued);

                var quotationNotIssued = totalRequests - quotationIssued;

                double quotationPercentage = 0;

                if (totalRequests > 0)
                    quotationPercentage =
                        (double)quotationIssued / totalRequests * 100;

                quotationPercentage = Math.Round(quotationPercentage, 2);

                #endregion


                #region KPI - Trends (Monthly)

                var trends = await query
                    .GroupBy(x => new { x.RequestDate.Year, x.RequestDate.Month })
                    .Select(g => new RequestsTrendDto
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Submitted = g.Count(x =>
                            x.DocumentStatus == InspectionDocumentStatus.Submitted),
                        Closed = g.Count(x =>
                            x.DocumentStatus == InspectionDocumentStatus.Closed)
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToListAsync();

                #endregion


                #region KPI - Requests Per Project

                var requestsPerProject = await query
                    .Where(x => x.CustomerProjectId != null)
                    .GroupBy(x => new
                    {
                        x.CustomerProjectId,
                        ProjectName = x.CustomerProjects.ProjectName
                    })
                    .Select(g => new RequestsPerProjectDto
                    {
                        ProjectId = g.Key.CustomerProjectId,
                        ProjectName = g.Key.ProjectName,
                        Total = g.Count(),
                        Submitted = g.Count(x =>
                            x.DocumentStatus == InspectionDocumentStatus.Submitted),
                        InProgress = g.Count(x =>
                            x.DocumentStatus == InspectionDocumentStatus.InProgress),
                        Scheduled = g.Count(x =>
                            x.DocumentStatus == InspectionDocumentStatus.Scheduled),
                        Closed = g.Count(x =>
                            x.DocumentStatus == InspectionDocumentStatus.Closed),
                        Cancelled = g.Count(x =>
                            x.DocumentStatus == InspectionDocumentStatus.Cancelled)
                    })
                    .OrderByDescending(x => x.Total)
                    .ToListAsync();

                #endregion


                #region Alerts

                int slaDays = 3;
                int pendingDaysThreshold = 2;
                var today = DateTime.UtcNow;

                // Overdue Requests
                var overdueRequests = await query
                    .Where(x =>
                        x.RequestedInspectionDate.HasValue &&
                        x.RequestedInspectionDate.Value.AddDays(slaDays) < today &&
                        x.DocumentStatus != InspectionDocumentStatus.Closed &&
                        x.DocumentStatus != InspectionDocumentStatus.Cancelled)
                    .Select(x => new DashboardAlertDto
                    {
                        RequestNumber = x.RequestNumber,
                        CustomerName = x.Customers.Name,
                        ProjectName = x.CustomerProjects != null
                            ? x.CustomerProjects.ProjectName
                            : null,
                        AlertType = "Overdue",
                        Days = EF.Functions.DateDiffDay(
                            x.RequestedInspectionDate.Value.AddDays(slaDays),
                            today)
                    })
                    .ToListAsync();

                // Pending Scheduling
                var pendingSchedulingRequests = await query
                    .Where(x =>
                        x.DocumentStatus == InspectionDocumentStatus.Submitted &&
                        EF.Functions.DateDiffDay(x.RequestDate, today) >
                        pendingDaysThreshold)
                    .Select(x => new DashboardAlertDto
                    {
                        RequestNumber = x.RequestNumber,
                        CustomerName = x.Customers.Name,
                        ProjectName = x.CustomerProjects != null
                            ? x.CustomerProjects.ProjectName
                            : null,
                        AlertType = "PendingScheduling",
                        Days = EF.Functions.DateDiffDay(x.RequestDate, today)
                    })
                    .ToListAsync();

                var alerts = overdueRequests
                    .Concat(pendingSchedulingRequests)
                    .OrderByDescending(x => x.Days)
                    .ToList();

                var pendingSchedulingCount = pendingSchedulingRequests.Count;

                #endregion


                #region Final Dashboard Object

                var dashboard = new InspectionDashboardDto
                {
                    TotalRequests = totalRequests,
                    InProgressRequests = inProgress,
                    CancelledOrClosedRequests = cancelledOrClosed,
                    ScheduledRequests = scheduledRequests,
                    CompletedRequests = completedRequests,

                    RequestsByStatus = requestsByStatus,
                    LatestRequests = latestRequests,

                    RepeatCustomerPercentage = repeatCustomerPercentage,
                    QuotationIssuedRequests = quotationIssued,
                    QuotationNotIssuedRequests = quotationNotIssued,
                    QuotationIssuedPercentage = quotationPercentage,

                    RequestsPerCustomer = requestsPerCustomer,
                    RequestsPerProject = requestsPerProject,
                    PendingSchedulingRequests = pendingSchedulingCount,

                    Trends = trends,
                    Alerts = alerts
                };

                #endregion


                return ReturnBase<InspectionDashboardDto>.Success(dashboard);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionDashboardDto>.Fail(ex, _exceptionManager);
            }
        }

    }
}
