using Inspection.Application.Contracts.Dto.Inspection.JobOrderDashboard;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDashboard;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.JobOrderDashboard;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection
{
    public class JobOrderDashboardQueryRepository
        : QueryRepositoryBase<JobOrder>, IJobOrderDashboardQueryRepository
    {
        public JobOrderDashboardQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        { }




        public async Task<ReturnBase<JobOrderDashboardDto>> GetDashboardAsync(JobOrderDashboardFilterDto filter)
        {
            try
            {
                var dateFrom = filter.DateFrom?.Date ?? DateTime.UtcNow.Date;
                var dateTo = filter.DateTo?.Date ?? DateTime.UtcNow.Date;

                var dateToExclusive = dateTo.AddDays(1);

                var firstDayOfMonth = new DateTime(dateFrom.Year, dateFrom.Month, 1);

                var jobOrdersQuery = _dbSet.AsNoTracking().AsQueryable();

                if (filter.CustomerId.HasValue)
                {
                    jobOrdersQuery = jobOrdersQuery.Where(j => j.CustomerId == filter.CustomerId.Value);
                }

                if (filter.ApprovalStatus.HasValue)
                {
                    jobOrdersQuery = jobOrdersQuery.Where(j =>
                        j.ApprovalStatus == filter.ApprovalStatus.Value);
                }

                jobOrdersQuery = jobOrdersQuery.Where(j =>
            j.PlannedStartDate >= dateFrom &&
            j.PlannedStartDate < dateToExclusive
        );

                #region Job Orders KPIs

                var totalJobOrders = await jobOrdersQuery.CountAsync();

                var activeJobs = await jobOrdersQuery.CountAsync(j =>
                    j.DocumentStatus == JobOrderDocumentStatus.Scheduled ||
                    j.DocumentStatus == JobOrderDocumentStatus.InProgress);

                var completedJobs = await jobOrdersQuery.CountAsync(j =>
                    j.DocumentStatus == JobOrderDocumentStatus.Closed);

                var cancelledJobs = await jobOrdersQuery.CountAsync(j =>
                    j.DocumentStatus == JobOrderDocumentStatus.Cancelled);

                var jobsInRange = totalJobOrders;

                var delayedJobs = await jobOrdersQuery.CountAsync(j =>
                    j.PlannedEndDate < dateFrom &&
                    j.DocumentStatus != JobOrderDocumentStatus.Closed);

                var jobDelayRate = totalJobOrders > 0
                    ? (double)delayedJobs / totalJobOrders * 100
                    : 0;

                #endregion

                #region Service KPIs

                var totalServicesRequested = await jobOrdersQuery
                    .SelectMany(j => j.JobOrderLines)
                    .SumAsync(l => (int?)l.PlannedQuantity) ?? 0;

                var servicesCompleted = await jobOrdersQuery
                    .SelectMany(j => j.JobOrderLines)
                    .SumAsync(l => (int?)l.CompletedQuantity) ?? 0;

                var pendingServices = Math.Max(0, totalServicesRequested - servicesCompleted);

                var serviceCompletionRate = totalServicesRequested > 0
                    ? Math.Min((double)servicesCompleted / totalServicesRequested * 100, 100)
                    : 0;

                #endregion

                #region Inspector KPIs

                var totalInspectors = await _context.Set<Inspector>().CountAsync();

                var inspectorsScheduled = await _context.Set<JobOrderLine>()
                    .Where(l =>
                        l.ScheduledFromTime >= dateFrom &&
                        l.ScheduledFromTime < dateToExclusive &&
                        l.InspectorId != null)
                    .Select(l => l.InspectorId)
                    .Distinct()
                    .CountAsync();

                var totalAssignments = await _context.Set<JobOrderLine>()
                    .CountAsync(l =>
                        l.ScheduledFromTime >= dateFrom &&
                        l.ScheduledFromTime < dateToExclusive);

                var jobsPerInspector = totalInspectors > 0
                    ? (double)totalAssignments / totalInspectors
                    : 0;

                var inspectors = await _context.Set<Inspector>()
                    .Select(i => new
                    {
                        i.Id,
                        ScheduledHours = _context.Set<JobOrderLine>()
                            .Where(l =>
                                l.InspectorId == i.Id &&
                                l.ScheduledFromTime >= dateFrom &&
                                l.ScheduledFromTime < dateToExclusive)
                            .Sum(l => (int?)EF.Functions.DateDiffHour(l.ScheduledFromTime, l.ScheduledToTime)) ?? 0
                    })
                    .ToListAsync();

                var inspectorUtilizationPerInspector = inspectors
                    .Select(x => new InspectorUtilizationDto
                    {
                        InspectorId = x.Id,
                        UtilizationPercent = x.ScheduledHours / 8.0 * 100
                    })
                    .ToList();

                var scheduledHours = inspectors.Sum(x => x.ScheduledHours);

                var availableInspectors = totalInspectors - inspectorsScheduled;

                var availableHours = totalInspectors * 8;

                var inspectorUtilization = availableHours > 0
                    ? (double)scheduledHours / availableHours * 100
                    : 0;

                #endregion

                #region Scheduling KPIs

                var scheduledInspections = await _context.Set<JobOrderLine>()
                    .CountAsync(l =>
                        l.ScheduledFromTime >= dateFrom &&
                        l.ScheduledFromTime < dateToExclusive);

                #endregion

                #region On-Time Completion & Inspection KPIs

                var completedJobsOnTime = await jobOrdersQuery.CountAsync(j =>
                    j.DocumentStatus == JobOrderDocumentStatus.Closed &&
                    j.PlannedEndDate < dateToExclusive);

                var onTimeCompletionRate = completedJobs > 0
                    ? (double)completedJobsOnTime / completedJobs * 100
                    : 0;

                var totalCertificates = await _context.Set<InspectionCertificate>().CountAsync();

                var failedInspectionChecklists = await _context.Set<InspectionChecklist>()
                    .CountAsync(c => c.Status != InspectionCheckListStatus.SafeToUse);

                var inspectionFailureRate = totalCertificates > 0
                    ? (double)failedInspectionChecklists / totalCertificates * 100
                    : 0;

                #endregion

                #region Revenue KPIs

                var totalRevenue = await _dbSet
                    .Where(j => j.SalesOrder != null)
                    .SumAsync(j => (decimal?)j.SalesOrder.TotalAmount) ?? 0;

                var revenuePerJob = totalJobOrders > 0
                    ? totalRevenue / totalJobOrders
                    : 0;

                #endregion

                #region Equipment KPIs

                var totalEquipmentInspections = await _context.Set<InspectionChecklist>()
                    .CountAsync(c => c.EquipmentId != null);

                var totalEquipmentInspected = await _context.Set<InspectionChecklist>()
                    .Where(c => c.EquipmentId != null)
                    .Select(c => c.EquipmentId)
                    .Distinct()
                    .CountAsync();

                var passedInspections = await _context.Set<InspectionChecklist>()
                    .CountAsync(c => c.Status == InspectionCheckListStatus.SafeToUse);

                var failedEquipmentInspections = await _context.Set<InspectionChecklist>()
                    .CountAsync(c => c.Status != InspectionCheckListStatus.SafeToUse);

                var equipmentFailureRate = totalEquipmentInspections > 0
                    ? (double)failedEquipmentInspections / totalEquipmentInspections * 100
                    : 0;

                #endregion

                #region Certificates KPIs

                var certificatesIssued = await _context.Set<InspectionCertificate>().CountAsync();

                var certificatesIssuedInRange = await _context.Set<InspectionCertificate>()
                    .CountAsync(c =>
                        c.IssueDate >= dateFrom &&
                        c.IssueDate < dateToExclusive);

                var certificatesIssuedThisMonth = await _context.Set<InspectionCertificate>()
                    .CountAsync(c => c.IssueDate >= firstDayOfMonth);

                var checklistWithCertificates = await _context.Set<InspectionCertificate>()
                    .Select(c => c.InspectionChecklistId)
                    .ToListAsync();

                var pendingCertificates = await _context.Set<InspectionChecklist>()
                    .Where(c => !checklistWithCertificates.Contains(c.Id))
                    .CountAsync();

                #endregion

                #region Build DTO

                var dashboard = new JobOrderDashboardDto
                {
                    TotalJobOrders = totalJobOrders,
                    ActiveJobs = activeJobs,
                    CompletedJobs = completedJobs,
                    CancelledJobs = cancelledJobs,
                    JobsStartingToday = jobsInRange,
                    DelayedJobs = delayedJobs,
                    JobDelayRate = jobDelayRate,

                    TotalServicesRequested = totalServicesRequested,
                    ServicesCompleted = servicesCompleted,
                    PendingServices = pendingServices,
                    ServiceCompletionRate = serviceCompletionRate,

                    TotalInspectors = totalInspectors,
                    ActiveInspectorsToday = inspectorsScheduled,
                    JobsPerInspector = jobsPerInspector,
                    InspectorUtilization = inspectorUtilizationPerInspector,
                    InspectorUtilizationPercent = inspectorUtilization,
                    AvailableInspectors = availableInspectors,

                    ScheduledInspectionsToday = scheduledInspections,

                    TotalEquipmentInspected = totalEquipmentInspected,
                    PassedInspections = passedInspections,
                    FailedInspections = failedEquipmentInspections,
                    EquipmentFailureRate = equipmentFailureRate,

                    CertificatesIssued = certificatesIssued,
                    CertificatesIssuedToday = certificatesIssuedInRange,
                    CertificatesIssuedThisMonth = certificatesIssuedThisMonth,
                    PendingCertificates = pendingCertificates,

                    OnTimeCompletionRate = onTimeCompletionRate,
                    InspectionFailureRate = inspectionFailureRate,

                    TotalRevenue = totalRevenue,
                    RevenuePerJob = revenuePerJob
                };

                #endregion

                return ReturnBase<JobOrderDashboardDto>.Success(dashboard);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobOrderDashboardDto>.Fail(ex, _exceptionManager);
            }
        }

    }
}