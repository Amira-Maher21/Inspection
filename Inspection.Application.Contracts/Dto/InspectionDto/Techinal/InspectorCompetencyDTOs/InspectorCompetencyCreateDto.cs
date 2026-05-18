using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs
{
    public class InspectorCompetencyCreateDto
    {
        public long CompanyId { get; set; }
        public long InspectorId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Notes { get; set; }

        public List<InspectorCompetencyLineCreateDto> InspectorCompetencyLines { get; set; } = new List<InspectorCompetencyLineCreateDto>();
        public List<InspectorAccreditationCreateDto> InspectorAccreditation { get; set; } = new List<InspectorAccreditationCreateDto>();
    }
}