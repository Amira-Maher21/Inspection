namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class MonthlyConversionDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Total { get; set; }
        public int Approved { get; set; }
        public double ConversionRate { get; set; }
        public decimal ApprovedValue { get; set; }
        public decimal LostRevenue { get; set; }

    }

}
