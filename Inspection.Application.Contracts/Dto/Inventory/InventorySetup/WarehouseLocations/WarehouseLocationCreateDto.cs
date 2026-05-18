namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationCreateDto
    {

        public long? ParentLocationId { get; set; }

        public long WarehouseId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;


        public string LocationType { get; set; } = null!;

        public bool IsLeaf { get; set; } = true;

        public decimal? Capacity { get; set; }

        public string? Description { get; set; }

    }
}
