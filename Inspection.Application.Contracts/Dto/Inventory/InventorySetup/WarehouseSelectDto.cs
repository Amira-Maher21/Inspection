namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup
{
    public class WarehouseSelectDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}