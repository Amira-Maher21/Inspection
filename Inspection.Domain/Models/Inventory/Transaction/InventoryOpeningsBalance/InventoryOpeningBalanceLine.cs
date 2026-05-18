using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Inventory.InventorySetup.Batchs;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance
{
    public class InventoryOpeningBalanceLine : IAuditable
    {
        public long Id { get; private set; }

        // Parent
        public long InventoryOpeningBalanceId { get; set; }
        public InventoryOpeningBalance InventoryOpeningBalance { get; set; } = null!;

        // Quantities & Cost
        public decimal Quantity { get; private set; }
        public decimal UnitCost { get; private set; }              // Unit Cost
        public decimal TotalCost { get; private set; }         // Quantity * Cost

        public DateTime? ExpiryDate { get; private set; }
        public string? SerialNumber { get; private set; }
        public string? Notes { get; private set; }

        // FK
        public long ItemId { get; private set; }
        public Item Item { get; private set; } = null!;
        public long? WarehouseLocationId { get; private set; }
        public WarehouseLocation? WarehouseLocation { get; private set; }

        public long? BatchId { get; private set; }
        public Batch? Batch { get; private set; }

        public long? CostCenterId { get; private set; }
        public CostCenter? CostCenter { get; private set; }

        public long? CostUnitId { get; private set; }
        public CostUnit? CostUnit { get; private set; }

        public long? OperationId { get; private set; }
        public Operation? Operation { get; private set; }

        // Project / Cost Dimensions
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