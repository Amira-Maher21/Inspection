using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.InventorySetup.Batchs
{
    public class Batch : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string BatchNumber { get; private set; }

        public long CompanyId { get; private set; }
        public long ItemId { get; private set; }
        public Item Item { get; private set; }

        public DateTime? ManufactureDate { get; private set; }
        public DateTime? ExpiryDate { get; private set; }


        // Audit 
        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
