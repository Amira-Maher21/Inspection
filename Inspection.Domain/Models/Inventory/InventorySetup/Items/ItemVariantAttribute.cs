
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.InventorySetup.Items
{
    public class ItemVariantAttribute : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;

        public long ItemId { get; private set; } // Variant Item
        public Item Item { get; set; } = null!;

        public long AttributeId { get; set; }
        public ItemAttribute.ItemAttribute ItemAttribute { get; set; } = null!;

        public long ItemAttributeValueId { get; set; }
        public ItemAttributeValue ItemAttributeValue { get; set; } = null!;

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}