namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemReorderPerWarehouseDTOs
{
    public class ItemReorderPerWarehouseCreateDto
    {
        public long? DefaultWarehouseId { get; set; }
        public decimal ReorderLevel { get; set; }
        public decimal ReorderQuantity { get; set; }
        public decimal? SafetyStock { get; set; }
    }
}