namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class HighestValueCustomerDto
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalValue { get; set; }
    }

}
