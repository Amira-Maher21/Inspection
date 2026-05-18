namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationSelectDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
