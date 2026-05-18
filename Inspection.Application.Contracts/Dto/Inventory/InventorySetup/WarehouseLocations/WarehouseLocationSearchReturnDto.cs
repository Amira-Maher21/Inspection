namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationSearchReturnDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public long WarehouseId { get; set; }
        public string? WarehouseCode { get; set; }
        public string? WarehouseName { get; set; }

        public long? ParentLocationId { get; set; }
        public string LocationType { get; set; } = string.Empty;
        public bool IsLeaf { get; set; }
        public decimal? Capacity { get; set; }
        public string? Description { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
    }
}
