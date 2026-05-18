namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers
{
    public class InventoryCostLayerDto
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long CompanyId { get; set; }
        public long WarehouseId { get; set; }

        public decimal QuantityIn { get; set; }
        public decimal QuantityOut { get; set; }
        public decimal RemainingQty { get; set; }
        public decimal UnitCost { get; set; }
        public long ReferenceDocumentId { get; set; }
        public DateTime TransactionDate { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}