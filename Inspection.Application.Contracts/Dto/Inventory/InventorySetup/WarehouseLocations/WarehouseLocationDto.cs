namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationDto
    {
        public long Id { get; set; }

        public long? ParentLocationId { get; set; }

        public long WarehouseId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;


        public string LocationType { get; set; } = null!;

        public bool IsLeaf { get; set; } = true;

        public decimal? Capacity { get; set; }

        public string? Description { get; set; }


        public string Tenant_ID { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
