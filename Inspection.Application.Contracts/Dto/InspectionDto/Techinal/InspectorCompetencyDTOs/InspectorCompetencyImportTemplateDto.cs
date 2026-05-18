namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs
{
    public class InspectorCompetencyImportTemplateDto
    {
        public long CompanyId { get; set; }
        public long InspectorId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Notes { get; set; }
    }
}
