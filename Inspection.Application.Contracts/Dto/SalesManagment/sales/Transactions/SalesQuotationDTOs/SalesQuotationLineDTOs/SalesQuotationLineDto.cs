namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs.SalesQuotationLineDTOs
{
    public class SalesQuotationLineDto
    {
        public long Id { get; set; }
        public long SalesQuotationId { get; set; }

        public string? Description { get; set; }

        public long ItemId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }

        public long? InspectionMethodId { get; set; }

        public string? Notes { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
