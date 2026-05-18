using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.System.InventoryLedgers
{
    public class InventoryLedger : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public long WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public long CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;

        public string DocumentNumber { get; set; } = string.Empty;

        public long? WarehouseLocationId { get; set; }
        public WarehouseLocation? WarehouseLocation { get; set; }

        public long ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public long UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal? QuantityIn { get; set; }
        public decimal? QuantityOut { get; set; }

        public decimal BalanceAfter { get; set; }

        public decimal? UnitCost { get; set; }
        public decimal TransactionValue { get; set; }


        public bool IsReversed { get; set; }
        public int ReversedFromId { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDeleted { get; set; }

        public string TransactionType { get; set; } = null!;
        public string? SourceType { get; set; }
        public long? ReferenceDocumentId { get; set; }
        public long? ReferenceDocumentLineId { get; set; }


        public CostingMethodEnum CostingMethod { get; set; }  // FIFO / Average

        //public bool IsPosted { get; set; }

        public string? Description { get; set; }
        //public string? ArabicDescription { get; set; }

        public long PostingDocumentTypeId { get; set; }
        public PostingDocumentType PostingDocumentType { get; set; } = null!;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}