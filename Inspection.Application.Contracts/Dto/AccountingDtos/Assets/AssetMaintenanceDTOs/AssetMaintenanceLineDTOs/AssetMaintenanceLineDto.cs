using Inspection.Domain.Enums.Accounting.Assets.AssetMaintenances;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs.AssetMaintenanceLineDTOs
{
    public class AssetMaintenanceLineDto
    {
        public long Id { get; set; }
        public long AssetMaintenanceId { get; set; }
        public long AssetId { get; set; }
        public string WorkDescription { get; set; } = string.Empty;
        public MaintenanceActionType MaintenanceActionType { get; set; }
        public decimal? DowntimeHours { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public bool IsCapitalizable { get; set; }
        public long? WBSId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQItemId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }
        public long? CostCodeId { get; set; }
        public long? OperationId { get; set; }
        public long? CostCenterId { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}