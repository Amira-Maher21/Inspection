using Inspection.Domain.Event;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines
{
    public class GoodsReceiptLine : IAuditable, IPostingLineEntity
    {
        public long Id { get; private set; }
        public long GoodsReceiptId { get; set; }
        public GoodsReceipt GoodsReceipt { get; set; } = null!;

        public long ItemId { get; private set; }
        public Item Item { get; private set; } = null!;

        public long UnitOfMeasureId { get; private set; }
        public UnitOfMeasure UnitOfMeasure { get; private set; } = null!;

        public decimal Quantity { get; private set; }
        public decimal Cost { get; private set; }
        public decimal TotalCost { get; private set; }

        public long? WarehouseId { get; private set; }
        public Warehouse? Warehouse { get; private set; }

        public long? WarehouseLocationId { get; private set; }
        public WarehouseLocation? WarehouseLocation { get; private set; }

        public bool? FreeItem { get; private set; }
        public string? Notes { get; set; }

        public long? CostCenterId { get; set; }
        public CostCenter? CostCenter { get; set; }

        public long? CostUnitId { get; set; }
        public CostUnit? CostUnit { get; set; }

        public long? OperationId { get; set; }
        public Operation? Operation { get; set; }

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


        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}