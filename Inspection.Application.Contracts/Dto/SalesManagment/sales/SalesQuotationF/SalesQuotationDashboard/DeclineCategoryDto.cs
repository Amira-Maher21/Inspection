namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class DeclineCategoryDto
    {
        public string Category { get; set; }
        public int Count { get; set; }
        public decimal LostValue { get; set; }
    }
}
