namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs
{
    public class InspectorCompetencyLineCreateDto
    {
        public long InspectionMethodId { get; set; }
        public long? InspectionTypeId { get; set; }
        public string MaxLevel { get; set; } = string.Empty;
        public string? CertificationNo { get; set; }
        public DateTime? CertificationExpiry { get; set; }
        public bool Disabled { get; set; } = false;

    }
}