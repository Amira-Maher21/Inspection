using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard.Inspection.Application.Contracts.Dto.SalesManagement.Dashboard;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class SalesQuotationDashboardDto
    {
        // Executive KPIs
        public int TotalQuotations { get; set; }
        public int ApprovedQuotations { get; set; }
        public int DeclinedQuotations { get; set; }
        public int PendingQuotations { get; set; }

        public decimal TotalQuotationValue { get; set; }
        public decimal ApprovedValue { get; set; }
        public decimal LostValue { get; set; }

        public double ConversionRate { get; set; }

        // Sales Performance
        public List<SalesPersonPerformanceDto> SalesPerformance { get; set; }

        // Status Breakdown
        public List<QuotationByStatusDto> QuotationsByStatus { get; set; }

        // Decline Analysis
        public List<DeclineReasonDto> DeclineReasons { get; set; }

        // Monthly Trends
        public List<QuotationTrendDto> Trends { get; set; }

        // Alerts
        public List<DashboardAlertDto> Alerts { get; set; }

        public List<StatusPercentageDto> StatusBreakdown { get; set; }

        public List<RejectionByServiceDto> RejectionByService { get; set; }

        public decimal AverageQuotationValue { get; set; }
        public decimal PipelineValue { get; set; }
        public double AverageCloseDays { get; set; }
        public int AgingQuotations { get; set; }

        public SalesPersonPerformanceDto? BestSalesPerson { get; set; }
        public SalesPersonPerformanceDto? FastestSalesPerson { get; set; }
        public SalesPersonPerformanceDto? SlowestSalesPerson { get; set; }

        public DeclineReasonDto? WorstDeclineReason { get; set; }

        public HighestValueCustomerDto? HighestValueCustomer { get; set; }

        public List<MonthlyConversionDto> MonthlyConversion { get; set; } = new();

        public double AvgDeclineDays { get; set; }

        public List<DeclineCategoryDto> DeclineByCategory { get; set; }
        public List<DeclineHeatmapDto> DeclineHeatmap { get; set; }

    }

}
