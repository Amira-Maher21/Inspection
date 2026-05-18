namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines
{
    public class GoodsReceiptLineReturnSearchDto
    {
        public long Id { get; set; }
        public long GoodsReceiptId { get; set; }

        public long ItemId { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }

        public long? WarehouseLocationId { get; set; }
        public string? WarehouseLocationCode { get; set; }
        public string? WarehouseLocationName { get; set; }

        public long UomId { get; set; }
        public string? UomCode { get; set; }
        public string? UomName { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public string? Description { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}