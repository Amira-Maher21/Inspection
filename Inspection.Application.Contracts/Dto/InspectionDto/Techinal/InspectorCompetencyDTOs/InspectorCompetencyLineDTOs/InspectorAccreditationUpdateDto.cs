namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs
{
    public class InspectorAccreditationUpdateDto
    {
        public long Id { get; set; }

        public long AccreditationBodyId { get; set; }

        public string CertificateNumber { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string? Notes { get; set; }

    }
}