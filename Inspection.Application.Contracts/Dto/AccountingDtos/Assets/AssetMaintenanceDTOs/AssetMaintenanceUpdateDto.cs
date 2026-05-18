using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs.AssetMaintenanceLineDTOs;
using Inspection.Domain.Enums.Accounting.Assets.AssetMaintenances;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs
{
    public class AssetMaintenanceUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public AssetMaintenanceType MaintenanceType { get; set; }
        public FrequencyType? FrequencyTypeId { get; set; }
        public float? FrequencyValue { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public long? SupplierId { get; set; }
        public string? Technician { get; set; }
        public decimal? TotalEstimatedCost { get; set; }
        public decimal? TotalActualCost { get; set; }
        public bool InspectionRequired { get; set; }
        public InspectionResult? InspectionResult { get; set; }
        public string? CertificateNumber { get; set; }
        public string? Description { get; set; }
        public AssetMaintenanceDocumentStatus DocumentStatus { get; set; }
        public bool IsApproved { get; set; }

        public List<AssetMaintenanceLineUpdateDto> AssetMaintenanceLines { get; set; } = new();
    }
}