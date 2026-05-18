namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs
{
    public class InspectorAccreditationDto
    {
        public long Id { get; set; }

        public long InspectorCompetencyId { get; set; }
        public long AccreditationBodyId { get; set; }

        public string CertificateNumber { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string? Notes { get; set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}