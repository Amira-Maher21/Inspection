namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs.SalesQuotationLineDTOs
{
    public class SalesQuotationLineCreateDto
    {
        public string? Description { get; set; }
        public long ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public long? InspectionMethodId { get; set; }
        public string? Notes { get; set; }
    }
}