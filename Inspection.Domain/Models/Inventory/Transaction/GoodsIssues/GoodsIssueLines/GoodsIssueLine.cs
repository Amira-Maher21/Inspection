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

namespace Inspection.Domain.Models.Inventory.Transaction.GoodsIssues.GoodsIssueLines
{
    public class GoodsIssueLine : IAuditable
    {

        public long Id { get; set; }

        public long GoodsIssueId { get; set; }
        public GoodsIssue GoodsIssue { get; set; }

        public long ItemId { get; set; }
        public Item Item { get; set; }

        public long UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public decimal Quantity { get; set; }

        public decimal? Cost { get; set; }

        public long? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public long? WarehouseLocationId { get; set; }
        public WarehouseLocation? WarehouseLocation { get; set; }

        public bool? FreeItem { get; set; }

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


        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
