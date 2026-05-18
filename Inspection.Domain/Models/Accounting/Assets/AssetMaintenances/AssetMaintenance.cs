using Inspection.Domain.Enums.Accounting.Assets.AssetMaintenances;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.AssetMaintenances
{
    public class AssetMaintenance : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;

        // Maintenance Info
        public string MaintenanceCode { get; set; } = string.Empty;

        public AssetMaintenanceType MaintenanceType { get; private set; }

        public FrequencyType? FrequencyTypeId { get; private set; }

        public float? FrequencyValue { get; private set; }

        // Dates
        public DateTime MaintenanceDate { get; private set; }

        public DateTime? PlannedStartDate { get; private set; }

        public DateTime? PlannedEndDate { get; private set; }

        // Supplier / Technician
        public long? SupplierId { get; private set; }
        public Supplier? Supplier { get; private set; }

        public string? Technician { get; private set; }

        // Costs
        public decimal? TotalEstimatedCost { get; private set; }

        public decimal? TotalActualCost { get; private set; }

        // Inspection
        public bool InspectionRequired { get; private set; }

        public InspectionResult? InspectionResult { get; private set; }

        public string? CertificateNumber { get; private set; }

        // Description
        public string? Description { get; private set; }

        // Document Status / Approval
        public AssetMaintenanceDocumentStatus DocumentStatus { get; private set; }

        public bool IsApproved { get; private set; }

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        //Details
        public List<AssetMaintenanceLine> AssetMaintenanceLines { get; set; } = null!;
    }
}