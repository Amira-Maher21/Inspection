using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies
{
    public class AccreditationBodyLine : IAuditable
    {
        public long Id { get; private set; }

        // Parent Accreditation Body
        public long AccreditationBodyId { get; set; }
        public AccreditationBody AccreditationBody { get; set; } = null!;

        // FK
        public long InspectionTypeId { get; set; }
        public InspectionType InspectionType { get; set; } = null!;

        public long InspectionStandardId { get; set; }
        public InspectionStandard InspectionStandard { get; set; } = null!;

        // Line Info
        public string? RiskLevel { get; private set; }
        public string? Description { get; private set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}