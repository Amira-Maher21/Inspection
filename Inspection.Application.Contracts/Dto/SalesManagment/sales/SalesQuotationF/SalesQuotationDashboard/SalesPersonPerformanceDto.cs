namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class SalesPersonPerformanceDto
    {
        public long SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }

        public int TotalQuotations { get; set; }
        public int ApprovedQuotations { get; set; }
        public int DeclinedQuotations { get; set; }

        public decimal TotalValue { get; set; }
        public decimal ApprovedValue { get; set; }
        public decimal LostValue { get; set; }
        public double AvgApprovalDays { get; set; }

        public double ConversionRate { get; set; }

        public decimal TargetAmount { get; set; }
        public double TargetAchievement { get; set; }

    }

}
