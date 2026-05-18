using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.InspectionStandardApplicabilityRules
{
    public class InspectionStandardApplicabilityRule : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public long StandardId { get; set; }
        public virtual InspectionStandard Standard { get; set; } = null!;
        public long EquipmentTypeId { get; private set; }
        public virtual EquipmentType EquipmentType { get; private set; } = null!;
        public long? InspectionTypeId { get; private set; }
        public InspectionType? InspectionType { get; private set; }

        public decimal? MinValue { get; private set; }
        public decimal? MaxValue { get; private set; }
        public string? Unit { get; private set; }
        public bool IsMandatory { get; private set; }
        public bool Disable { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;

        // Company
        public long CompanyId { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
