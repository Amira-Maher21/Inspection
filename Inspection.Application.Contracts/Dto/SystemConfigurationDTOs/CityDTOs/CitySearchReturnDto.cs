namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs
{
    public class CitySearchReturnDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long CountryId { get; private set; }

        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
    }
}
