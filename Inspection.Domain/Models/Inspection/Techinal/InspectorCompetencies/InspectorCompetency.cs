using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies
{
    public class InspectorCompetency : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long InspectorId { get; private set; }
        public Inspector Inspector { get; private set; } = null!;

        public DateTime IssueDate { get; private set; }
        public DateTime? ExpiryDate { get; private set; }
        public string? Notes { get; private set; }

        public List<InspectorCompetencyLine> InspectorCompetencyLines { get; set; } = null!;
        public List<InspectorAccreditation> InspectorAccreditation { get; set; } = null!;

        // series related
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}