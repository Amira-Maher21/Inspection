namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs
{
    public class CityUpdateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long CountryId { get; set; }

    }
}