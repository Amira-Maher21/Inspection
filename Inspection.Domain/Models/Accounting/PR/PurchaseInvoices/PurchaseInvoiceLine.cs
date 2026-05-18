using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.System.Taxes;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceLine : IAuditable
    {
        public long Id { get; private set; }


        public long PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; }

        public long? ItemId { get; private set; }
        public Item Item { get; private set; } = null!;


        public long UnitOfMeasureId { get; private set; }
        public UnitOfMeasure UnitOfMeasure { get; private set; } = null!;


        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }


        public long TaxTypeId { get; private set; }
        public TaxType TaxType { get; private set; } = null!;

        public decimal? TaxRate { get; private set; } = null!;
        public decimal? TaxAmount { get; private set; }
        public bool IsInclusive { get; private set; }

        public long? TaxTypeId2 { get; set; }
        public TaxType? TaxType2 { get; set; }
        public decimal? TaxRate2 { get; set; }
        public bool? IsInclusive2 { get; set; }
        public decimal? TaxAmount2 { get; set; }

        public DiscountType? DiscountType { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public decimal? DiscountAmount { get; private set; }


        public long? WarehouseId { get; private set; }
        public Warehouse? Warehouse { get; private set; }

        public long? WarehouseLocationId { get; private set; }
        public WarehouseLocation? WarehouseLocation { get; private set; }


        public bool FreeItem { get; private set; } = false;
        public string Notes { get; private set; } = string.Empty;

        public long? CostCenterId { get; private set; }
        public CostCenter? CostCenter { get; private set; }

        public long? CostUnitId { get; private set; }
        public CostUnit? CostUnit { get; private set; }

        public long? OperationId { get; private set; }
        public Operation? Operation { get; private set; }


        public long? WBSId { get; private set; }
        public WBS? WBS { get; private set; }

        public long? CostCodeId { get; private set; }
        public CostCode? CostCode { get; private set; }

        public long? ActivityId { get; private set; }
        public Activity? Activity { get; private set; }

        public long? SubcontractBOQId { get; private set; }
        public SubcontractBOQ? SubcontractBOQ { get; private set; }

        public long? ProductionOrderId { get; private set; }
        public ProductionOrder? ProductionOrder { get; private set; }

        public long? BOQLineId { get; private set; }
        public BOQLine? BOQLine { get; private set; }

        public decimal? Cost { get; private set; }

        public LineTypeEnum? LineType { get; private set; }
        public FixedAsset? FixedAsset { get; private set; }
        public long? AssetId { get; private set; }
        public AssetTransactionTypeEnum? AssetTransactionType { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}