using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders
{
    public class SalesOrderLines : IRootEntity, IAuditable
    {
        public long Id { get; set; }

        public long SalesOrderId { get; set; }
        public required SalesOrder SalesOrder { get; set; } = null!;

        public long? ItemId { get; set; }
        public Item? Item { get; set; }

        public long? UOMId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; } = null!;

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Discount { get; set; }

        public Warehouse Warehouse { get; set; } = null!;
        public long? WarehouseId { get; set; }

        public string Notes { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}