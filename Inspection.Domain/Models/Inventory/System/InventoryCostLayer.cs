using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.System
{
    public class InventoryCostLayer : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; }

        public long CompanyId { get; set; }

        public long ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public long PostingDocumentTypeId { get; set; }
        public PostingDocumentType PostingDocumentType { get; set; } = null!;

        public long WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public decimal QuantityIn { get; set; }
        public decimal QuantityOut { get; set; }
        public decimal RemainingQty { get; set; }
        public decimal UnitCost { get; set; }
        public long ReferenceDocumentId { get; set; }
        public DateTime TransactionDate { get; set; }




        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}