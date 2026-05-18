namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.salesOrderLines
{
    public class SalesOrderLinesDto
    {
        public long Id { get; set; }
        public long SalesOrderId { get; set; }

        public long? ItemId { get; set; }

        public long? UOMId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Discount { get; set; }

        public long? WarehouseId { get; set; }

        public string Notes { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}