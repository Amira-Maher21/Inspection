using Inspection.Domain.Enums.Accounting.Assets.AssetMaintenances;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.Assets.AssetMaintenances
{
    public class AssetMaintenanceLine : IAuditable
    {
        public long Id { get; private set; }

        // Parent
        public long AssetMaintenanceId { get; set; }
        public AssetMaintenance AssetMaintenance { get; set; } = null!;

        // Asset
        public long AssetId { get; private set; }
        public FixedAsset Asset { get; private set; } = null!;

        // Work Details
        public string WorkDescription { get; private set; } = string.Empty;
        public MaintenanceActionType MaintenanceActionType { get; private set; }
        public decimal? DowntimeHours { get; private set; }

        // Costs
        public decimal? EstimatedCost { get; private set; }
        public decimal? ActualCost { get; private set; }
        public bool IsCapitalizable { get; private set; }

        // Project / WBS / Costing
        public long? WBSId { get; private set; }
        public WBS? WBS { get; private set; }
        public long? ActivityId { get; private set; }
        public Activity? Activity { get; private set; }
        public long? BOQItemId { get; private set; }
        public BOQ? BOQ { get; private set; }
        public long? SubcontractBOQId { get; private set; }
        public SubcontractBOQ? SubcontractBOQ { get; private set; }
        public long? ProductionOrderId { get; private set; }
        public ProductionOrder? ProductionOrder { get; private set; }
        public long? CostCodeId { get; private set; }
        public CostCode? CostCode { get; private set; }
        public long? OperationId { get; private set; }
        public Operation? Operation { get; private set; }
        public long? CostCenterId { get; private set; }
        public CostCenter? CostCenter { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}