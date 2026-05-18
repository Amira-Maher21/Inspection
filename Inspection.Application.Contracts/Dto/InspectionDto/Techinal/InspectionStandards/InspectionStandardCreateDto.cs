namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards
{
    public class InspectionStandardCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public String Code { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public List<InspectionStandardApplicabilityRuleCreateDto> InspectionStandardApplicabilityRules { get; set; } = new List<InspectionStandardApplicabilityRuleCreateDto>();
    }
}
