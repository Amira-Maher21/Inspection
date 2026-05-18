using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies
{

    public class InspectorAccreditation : IAuditable
    {
        public long Id { get; set; }

        public long InspectorCompetencyId { get; set; }
        public long AccreditationBodyId { get; set; }

        public string CertificateNumber { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string? Notes { get; set; }

        public virtual InspectorCompetency InspectorCompetency { get; set; } = null!;
        public virtual AccreditationBody AccreditationBody { get; set; } = null!;


        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}