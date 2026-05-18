namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs
{
    public class CurrencyDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Sub_Currency { get; set; }
        public string CurrencySymbol { get; set; } = string.Empty;
        public bool Disabled { get; set; }


        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}