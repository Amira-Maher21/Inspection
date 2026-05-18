namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards
{
    public class InspectionStandardUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public String Code { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public List<InspectionStandardApplicabilityRuleUpdateDto> InspectionStandardApplicabilityRules { get; set; } = new List<InspectionStandardApplicabilityRuleUpdateDto>();
    }
}
