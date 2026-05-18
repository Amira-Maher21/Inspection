using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.System.InventoryBalances
{
    public class InventoryBalance : IRootEntity, ITenantEntity, IAuditable
    {
        public InventoryBalance() { }
        public InventoryBalance(
   long? itemId,
   long warehouseId,
   long? warehouseLocationId,
   long companyId,
   decimal quantity,
   decimal averageCost)
        {
            ItemId = itemId;
            WarehouseId = warehouseId;
            WarehouseLocationId = warehouseLocationId;
            CompanyId = companyId;
            Quantity = quantity;
            AvailableQuantity = quantity;
            AverageCost = averageCost;
            ReservedQuantity = 0;
            In_Date = DateTime.UtcNow;
            In_User = "system";
        }
        public long Id { get; set; }
        public long? ItemId { get; set; }
        public Item? Item { get; set; } = null!;
        public long WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;
        public long BaseUoMId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal AverageCost { get; set; }

        public long? WarehouseLocationId { get; set; }
        public WarehouseLocation? WarehouseLocation { get; set; } = null!;

        //company id
        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public void Increase(decimal qty, decimal unitCost)
        {
            if (qty <= 0) throw new ArgumentException("Quantity must be positive", nameof(qty));

            var totalCost = (Quantity * AverageCost) + (qty * unitCost);
            Quantity += qty;
            AvailableQuantity += qty;
            AverageCost = totalCost / Quantity;
        }

    }
}