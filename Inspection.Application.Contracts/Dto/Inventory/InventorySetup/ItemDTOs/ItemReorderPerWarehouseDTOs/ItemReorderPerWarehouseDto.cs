namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemReorderPerWarehouseDTOs
{
    public class ItemReorderPerWarehouseDto
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long? DefaultWarehouseId { get; set; }
        public decimal ReorderLevel { get; set; }
        public decimal ReorderQuantity { get; set; }
        public decimal? SafetyStock { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
