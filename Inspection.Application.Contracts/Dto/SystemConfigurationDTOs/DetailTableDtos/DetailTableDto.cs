namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.DetailTableDtos
{
    public class DetailTableDto
    {

        public long Id { get; set; }
        public long CurrencyExchangRateId { get; set; }
        public long CurrencyId { get; set; }
        public decimal Rate { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
