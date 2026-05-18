namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class DeclineReasonDto
    {
        public string Reason { get; set; }
        public int Count { get; set; }
        public decimal LostValue { get; set; }
        public double Percentage { get; set; }

    }

}
