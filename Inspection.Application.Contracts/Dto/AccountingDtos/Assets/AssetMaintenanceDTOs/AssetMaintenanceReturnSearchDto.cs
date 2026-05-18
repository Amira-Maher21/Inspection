using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs.AssetMaintenanceLineDTOs;
using Inspection.Domain.Enums.Accounting.Assets.AssetMaintenances;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs
{
    public class AssetMaintenanceReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public string MaintenanceCode { get; set; } = string.Empty;
        public AssetMaintenanceType MaintenanceType { get; set; }
        public FrequencyType? FrequencyTypeId { get; set; }
        public float? FrequencyValue { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }

        public long? SupplierId { get; set; }
        public long? SupplierCode { get; set; }
        public long? SupplierName { get; set; }

        public string? Technician { get; set; }
        public decimal? TotalEstimatedCost { get; set; }
        public decimal? TotalActualCost { get; set; }
        public bool InspectionRequired { get; set; }
        public InspectionResult? InspectionResult { get; set; }
        public string? CertificateNumber { get; set; }
        public string? Description { get; set; }
        public AssetMaintenanceDocumentStatus DocumentStatus { get; set; }
        public bool IsApproved { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public List<AssetMaintenanceLineDto> AssetMaintenanceLines { get; set; } = new();
    }
}