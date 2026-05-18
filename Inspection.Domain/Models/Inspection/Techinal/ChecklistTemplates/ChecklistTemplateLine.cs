using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateLine : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public long ChecklistTemplateId { get; set; }
        public ChecklistTemplate ChecklistTemplate { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public string ItemText { get; set; } = string.Empty;

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

    }
}
