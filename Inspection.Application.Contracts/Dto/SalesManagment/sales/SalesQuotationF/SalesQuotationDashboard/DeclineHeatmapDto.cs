namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard
{
    public class DeclineHeatmapDto
    {
        public string Reason { get; set; }
        public long SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }
        public int Count { get; set; }
        public decimal LostValue { get; set; }
    }
}
