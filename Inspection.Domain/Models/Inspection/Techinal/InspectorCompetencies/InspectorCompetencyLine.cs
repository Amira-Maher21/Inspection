using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies
{
    public class InspectorCompetencyLine : IAuditable
    {
        public long Id { get; private set; }

        // Parent Inspector Competency
        public long InspectorCompetencyId { get; set; }
        public InspectorCompetency InspectorCompetency { get; set; } = null!;

        // Inspection Method
        public long InspectionMethodId { get; set; }
        public InspectionMethod InspectionMethod { get; set; } = null!;

        // Inspection Type
        public long? InspectionTypeId { get; set; }
        public InspectionType? InspectionType { get; set; } = null!;

        public string MaxLevel { get; private set; } = string.Empty;
        public string? CertificationNo { get; private set; }
        public DateTime? CertificationExpiry { get; private set; }
        public bool Disabled { get; private set; } = false;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}