namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards
{
    public class InspectionStandardDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public String Code { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<InspectionStandardApplicabilityRuleDto> InspectionStandardApplicabilityRules { get; set; } = new List<InspectionStandardApplicabilityRuleDto>();


    }
}
