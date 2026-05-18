using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates
{
    public class ChecklistTemplate : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; } = null!;

        public long StandardId { get; set; }
        public InspectionStandard InspectionStandard { get; set; } = null!;
        public int Version { get; set; }
        public bool Disabled { get; set; }
        public List<ChecklistTemplateLine> ChecklistTemplateLines { get; set; } = new List<ChecklistTemplateLine>();
        public string Tenant_ID { get; set; } = string.Empty;

        // Company
        public long CompanyId { get; private set; }
        public Company Company { get; private set; } = null!;

        // series related
        public Series Series { get; set; }
        public long? SeriesId { get; set; }
        public string ChecklistTemplateNumber { get; set; }
        //public string RequestNumber { get; set; } = string.Empty;
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
