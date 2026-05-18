namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs
{
    public class InspectorCompetencyLineDto
    {
        public long Id { get; private set; }
        // Parent Inspector Competency
        public long InspectorCompetencyId { get; set; }
        // Inspection Method
        public long InspectionMethodId { get; set; }
        // Inspection Type
        public long? InspectionTypeId { get; set; }
        public string MaxLevel { get; set; } = string.Empty;
        public string? CertificationNo { get; set; }
        public DateTime? CertificationExpiry { get; set; }
        public bool Disabled { get; set; } = false;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}