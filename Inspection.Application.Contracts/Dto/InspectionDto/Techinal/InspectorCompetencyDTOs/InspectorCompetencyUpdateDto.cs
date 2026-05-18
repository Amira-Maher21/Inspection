using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs
{
    public class InspectorCompetencyUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }

        public long InspectorId { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Notes { get; set; }

        public List<InspectorCompetencyLineUpdateDto> InspectorCompetencyLines { get; set; } = new List<InspectorCompetencyLineUpdateDto>();
        public List<InspectorAccreditationUpdateDto> InspectorAccreditation { get; set; } = new List<InspectorAccreditationUpdateDto>();
    }
}