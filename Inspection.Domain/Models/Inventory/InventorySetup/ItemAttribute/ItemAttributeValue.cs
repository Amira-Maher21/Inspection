using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute
{
    public class ItemAttributeValue : IAuditable
    {
        public long Id { get; private set; }

        public long ItemAttributeId { get; set; }
        public ItemAttribute ItemAttribute { get; set; } = null!;

        public string AttributeValue { get; private set; } = string.Empty;

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}