namespace Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs
{
    public class SCurrencyExchangeRateListItemDto
    {
        public long Id { get; set; }
        public string BaseCurrencyName { get; set; } = string.Empty;
        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

    }
    public class SCurrencyExchangeRateLineListItemDto
    {
        public string TargetCurrencyName { get; set; } = string.Empty;
        public decimal Rate { get; set; }

    }
}