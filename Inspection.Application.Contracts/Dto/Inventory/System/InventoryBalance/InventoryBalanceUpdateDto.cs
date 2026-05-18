namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance
{
    public class InventoryBalanceUpdateDto
    {
        public long Id { get; set; }
        public long? ItemId { get; set; }
        public long WarehouseId { get; set; }
        public long BaseUoMId { get; set; }
        public decimal Quantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal AverageCost { get; set; }
        public long? WarehouseLocationId { get; set; }
    }
}