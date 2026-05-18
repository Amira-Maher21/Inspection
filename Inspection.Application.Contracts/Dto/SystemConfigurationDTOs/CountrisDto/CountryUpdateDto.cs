namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto
{
    public class CountryUpdateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}