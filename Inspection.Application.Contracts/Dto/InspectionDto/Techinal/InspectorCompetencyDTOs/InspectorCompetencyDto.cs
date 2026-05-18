using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs
{
    public class InspectorCompetencyDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long InspectorId { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Notes { get; set; }

        public List<InspectorCompetencyLineDto> InspectorCompetencyLines { get; set; } = new List<InspectorCompetencyLineDto>();
        public List<InspectorAccreditationDto> InspectorAccreditation { get; set; } = new List<InspectorAccreditationDto>();

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}