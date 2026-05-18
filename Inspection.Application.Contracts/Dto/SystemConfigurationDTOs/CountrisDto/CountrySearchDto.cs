namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto
{
    public class CountrySearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

    }
}
