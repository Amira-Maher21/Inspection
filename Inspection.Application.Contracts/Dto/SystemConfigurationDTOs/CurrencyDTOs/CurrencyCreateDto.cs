namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs
{
    public class CurrencyCreateDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Sub_Currency { get; set; }
        public string CurrencySymbol { get; set; } = string.Empty;
        public bool Disabled { get; set; }

    }
}
