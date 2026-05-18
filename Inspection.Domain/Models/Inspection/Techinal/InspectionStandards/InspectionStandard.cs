using Inspection.Domain.Models.Inspection.Techinal.InspectionStandardApplicabilityRules;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.InspectionStandards
{
    public class InspectionStandard : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public List<InspectionStandardApplicabilityRule> InspectionStandardApplicabilityRules { get; set; } = new List<InspectionStandardApplicabilityRule>();

        // Company
        public long CompanyId { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
