using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations
{

    public class WarehouseLocation : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public long? ParentLocationId { get; set; }

        public long WarehouseId { get; private set; }
        public Warehouse Warehouse { get; private set; }

        public string Code { get; private set; } = null!;

        public string Name { get; private set; } = null!;


        public string LocationType { get; private set; } = null!;

        public bool IsLeaf { get; set; } = true;

        public decimal? Capacity { get; private set; }

        public string? Description { get; private set; }


        public string Tenant_ID { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }


}
