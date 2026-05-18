using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.SalesQuotationDashboard;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagement
{

    public class SalesQuotationDashboardQueryRepository
        : QueryRepositoryBase<SalesQuotation>, ISalesQuotationDashboardQueryRepository
    {
        public SalesQuotationDashboardQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<SalesQuotationDashboardDto>>
     GetDashboardAsync(SalesQuotationDashboardFilterDto filter)
        {
            try
            {
                var today = DateTime.UtcNow.Date;

                #region Base Query + Filters

                var query = _dbSet.AsNoTracking().AsQueryable();

                if (filter.CustomerId.HasValue)
                    query = query.Where(x => x.CustomerId == filter.CustomerId);

                if (filter.SalesPersonId.HasValue)
                    query = query.Where(x => x.SalespersonId == filter.SalesPersonId);

                if (filter.FromDate.HasValue)
                    query = query.Where(x => x.QuotationDate >= filter.FromDate);

                if (filter.ToDate.HasValue)
                    query = query.Where(x => x.QuotationDate <= filter.ToDate);

                if (filter.ItemId.HasValue)
                    query = query.Where(x =>
                        x.SalesQuotationLines.Any(l => l.ItemId == filter.ItemId));

                if (filter.DocumentStatus.HasValue)
                    query = query.Where(x =>
                        x.DocumentStatus == filter.DocumentStatus);

                #endregion

                #region Core Summary (Single Projection)

                var summary = await query
                    .GroupBy(x => 1)
                    .Select(g => new
                    {
                        Total = g.Count(),
                        Approved = g.Count(x => x.DocumentStatus == SalesQuotationDocumentStatus.Approved),
                        Declined = g.Count(x => x.DocumentStatus == SalesQuotationDocumentStatus.Declined),
                        Pending = g.Count(x =>
                            x.DocumentStatus != SalesQuotationDocumentStatus.Approved &&
                            x.DocumentStatus != SalesQuotationDocumentStatus.Declined),
                        //x.DocumentStatus != SalesQuotationDocumentStatus.Expired),

                        TotalValue = g.Sum(x => (decimal?)x.TotalAmount) ?? 0,
                        ApprovedValue = g
                            .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Approved)
                            .Sum(x => (decimal?)x.TotalAmount) ?? 0,
                        LostValue = g
                            .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Declined)
                            .Sum(x => (decimal?)x.TotalAmount) ?? 0
                    })
                    .FirstOrDefaultAsync();

                summary ??= new { Total = 0, Approved = 0, Declined = 0, Pending = 0, TotalValue = 0m, ApprovedValue = 0m, LostValue = 0m };

                double conversionRate = summary.Total > 0
                    ? Math.Round((double)summary.Approved / summary.Total * 100, 2)
                    : 0;

                decimal averageValue = summary.Total > 0
                    ? Math.Round(summary.TotalValue / summary.Total, 2)
                    : 0;

                #endregion


                #region Status Percentage

                var statusBreakdown = await query
                    .GroupBy(x => x.ApprovalStatus)
                    .Select(g => new StatusPercentageDto
                    {
                        Status = g.Key,
                        Count = g.Count(),
                        Percentage = summary.Total > 0
                            ? Math.Round((double)g.Count() / summary.Total * 100, 2)
                            : 0
                    })
                    .ToListAsync();

                #endregion


                #region Sales Performance

                var salesPerformance = await query
                    .Where(x => x.SalespersonId.HasValue && x.Salesperson != null)
                    .GroupBy(x => new
                    {
                        x.SalespersonId,
                        x.Salesperson.Name,
                        x.Salesperson.TargetAmount
                    })
                    .Select(g => new SalesPersonPerformanceDto
                    {
                        SalesPersonId = g.Key.SalespersonId.Value,
                        SalesPersonName = g.Key.Name,
                        TotalQuotations = g.Count(),
                        ApprovedQuotations = g.Count(x => x.DocumentStatus == SalesQuotationDocumentStatus.Approved),
                        DeclinedQuotations = g.Count(x => x.DocumentStatus == SalesQuotationDocumentStatus.Declined),
                        TotalValue = g.Sum(x => x.TotalAmount),
                        ApprovedValue = g
                            .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Approved)
                            .Sum(x => x.TotalAmount),
                        LostValue = g
                            .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Declined)
                            .Sum(x => x.TotalAmount),
                        TargetAmount = g.Key.TargetAmount ?? 0,
                        AvgApprovalDays = g
                            .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Approved
                                        && x.QuotationDate.HasValue
                                        && x.Mod_Date.HasValue)
                            .Select(x => (double?)EF.Functions.DateDiffDay(
                                x.QuotationDate.Value,
                                x.Mod_Date.Value))
                            .Average() ?? 0
                    })
                    .ToListAsync();

                foreach (var sp in salesPerformance)
                {
                    sp.ConversionRate = sp.TotalQuotations > 0
                        ? Math.Round((double)sp.ApprovedQuotations / sp.TotalQuotations * 100, 2)
                        : 0;

                    sp.TargetAchievement = sp.TargetAmount > 0
                     ? Math.Round(
                         (double)((sp.ApprovedValue / sp.TargetAmount) * 100m), 2)
                     : 0;

                }

                #endregion

                #region Executive KPIs

                var bestSales = salesPerformance
                    .OrderByDescending(x => x.ConversionRate)
                    .FirstOrDefault();

                var fastestSales = salesPerformance
                    .Where(x => x.AvgApprovalDays > 0)
                    .OrderBy(x => x.AvgApprovalDays)
                    .FirstOrDefault();

                var slowestSales = salesPerformance
                    .Where(x => x.AvgApprovalDays > 0)
                    .OrderByDescending(x => x.AvgApprovalDays)
                    .FirstOrDefault();

                var declineReasons = await query
                  .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Declined
                   && !string.IsNullOrEmpty(x.DocumentStatusDeclined))
                    .GroupBy(x => x.DocumentStatusDeclined)
                    .Select(g => new DeclineReasonDto
                    {
                        Reason = g.Key,
                        Count = g.Count(),
                        LostValue = g.Sum(x => x.TotalAmount)
                    })
                    .OrderByDescending(x => x.LostValue)
                    .ToListAsync();

                var worstReason = declineReasons.FirstOrDefault();
                var totalDeclines = declineReasons.Sum(x => x.Count);

                foreach (var reason in declineReasons)
                {
                    reason.Percentage = totalDeclines > 0
                        ? Math.Round((double)reason.Count / totalDeclines * 100, 2)
                        : 0;
                }

                var topCustomer = await query
                    .GroupBy(x => new { x.CustomerId, x.Customer.Name })
                    .Select(g => new HighestValueCustomerDto
                    {
                        CustomerId = g.Key.CustomerId,
                        CustomerName = g.Key.Name,
                        TotalValue = g.Sum(x => x.TotalAmount)
                    })
                    .OrderByDescending(x => x.TotalValue)
                    .FirstOrDefaultAsync();

                #endregion

                #region Time KPIs




                var avgCloseDays = await query
                    .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Approved
                                && x.QuotationDate.HasValue
                                && x.Mod_Date.HasValue)
                    .Select(x => (double?)EF.Functions.DateDiffDay(
                        x.QuotationDate.Value,
                        x.Mod_Date.Value))
                    .AverageAsync() ?? 0;

                var avgDeclineDays = await query
                    .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Declined
                                && x.QuotationDate.HasValue
                                && x.Mod_Date.HasValue)
                    .Select(x => (double?)EF.Functions.DateDiffDay(
                        x.QuotationDate.Value,
                        x.Mod_Date.Value))
                    .AverageAsync() ?? 0;

                #endregion

                #region Monthly Conversion

                var monthlyConversion = await query
                    .Where(x => x.QuotationDate.HasValue)
                    .GroupBy(x => new
                    {
                        x.QuotationDate.Value.Year,
                        x.QuotationDate.Value.Month
                    })
                    .Select(g => new MonthlyConversionDto
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,

                        Total = g.Count(),

                        Approved = g.Count(x =>
                            x.DocumentStatus == SalesQuotationDocumentStatus.Approved),

                        ApprovedValue = g
                    .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Approved)
                    .Sum(x => (decimal?)x.TotalAmount) ?? 0,

                        LostRevenue = g
                    .Where(x => x.DocumentStatus == SalesQuotationDocumentStatus.Declined)
                    .Sum(x => (decimal?)x.TotalAmount) ?? 0,

                        ConversionRate = g.Count() > 0
                    ? Math.Round(
                        (double)g.Count(x =>
                            x.DocumentStatus == SalesQuotationDocumentStatus.Approved)
                        / g.Count() * 100, 2)
                    : 0
                    })

                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToListAsync();

                #endregion

                #region Pipeline & Aging

                var pipelineValue = await query
                    .Where(x =>
                        x.DocumentStatus != SalesQuotationDocumentStatus.Approved &&
                        x.DocumentStatus != SalesQuotationDocumentStatus.Declined)
                    //x.DocumentStatus != SalesQuotationDocumentStatus.Expired)
                    .SumAsync(x => (decimal?)x.TotalAmount) ?? 0;

                var agingDays = filter.AgingDays ?? 7;

                var agingCount = await query
                    .Where(x =>
                        x.DocumentStatus != SalesQuotationDocumentStatus.Approved &&
                        x.DocumentStatus != SalesQuotationDocumentStatus.Declined &&
                        //x.DocumentStatus != SalesQuotationDocumentStatus.Expired &&
                        EF.Functions.DateDiffDay(x.In_Date, today) > agingDays)
                    .CountAsync();

                #endregion

                #region Final DTO

                var dashboard = new SalesQuotationDashboardDto
                {
                    TotalQuotations = summary.Total,
                    ApprovedQuotations = summary.Approved,
                    DeclinedQuotations = summary.Declined,
                    PendingQuotations = summary.Pending,

                    TotalQuotationValue = summary.TotalValue,
                    ApprovedValue = summary.ApprovedValue,
                    LostValue = summary.LostValue,
                    ConversionRate = conversionRate,
                    AverageQuotationValue = averageValue,

                    SalesPerformance = salesPerformance,
                    BestSalesPerson = bestSales,
                    FastestSalesPerson = fastestSales,
                    SlowestSalesPerson = slowestSales,

                    DeclineReasons = declineReasons,
                    WorstDeclineReason = worstReason,
                    HighestValueCustomer = topCustomer,

                    MonthlyConversion = monthlyConversion,

                    AverageCloseDays = avgCloseDays,
                    AvgDeclineDays = avgDeclineDays,
                    StatusBreakdown = statusBreakdown,

                    PipelineValue = pipelineValue,
                    AgingQuotations = agingCount
                };

                #endregion

                return ReturnBase<SalesQuotationDashboardDto>.Success(dashboard);
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesQuotationDashboardDto>.Fail(ex, _exceptionManager);
            }
        }

    }
}
