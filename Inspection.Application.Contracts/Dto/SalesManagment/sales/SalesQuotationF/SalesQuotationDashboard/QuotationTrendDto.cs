namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class QuotationTrendDto
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public int Total { get; set; }
        public decimal ApprovedValue { get; set; }
        public decimal LostValue { get; set; }
    }

}
