namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class RejectionByServiceDto
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }

        public int RejectedCount { get; set; }

        public decimal LostValue { get; set; }

        public double RejectionRate { get; set; }
    }

}
