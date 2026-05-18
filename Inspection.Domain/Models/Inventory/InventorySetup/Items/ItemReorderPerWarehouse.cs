using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inventory.InventorySetup.Items
{
    public class ItemReorderPerWarehouse : IAuditable
    {
        public long Id { get; private set; }

        // Parent Item
        public long ItemId { get; set; }
        public Item Item { get; set; } = null!;

        // Warehouse
        public long? DefaultWarehouseId { get; private set; }
        public Warehouse? DefaultWarehouse { get; private set; }

        // ReOrder Info
        public decimal ReorderLevel { get; set; }
        public decimal ReorderQuantity { get; set; }
        public decimal? SafetyStock { get; set; }


        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}