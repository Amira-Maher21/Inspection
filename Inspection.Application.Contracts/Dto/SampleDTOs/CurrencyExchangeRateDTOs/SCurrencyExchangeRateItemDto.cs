namespace Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs
{
    public class SCurrencyExchangeRateItemDto
    {
        public long Id { get; set; }
        public long BaseCurrencyId { get; set; }
        public string BaseCurrencyName { get; set; } = string.Empty;
        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<SCurrencyExchangeRateDetailLine> Lines { get; set; } = new List<SCurrencyExchangeRateDetailLine>();

        public class SCurrencyExchangeRateDetailLine
        {
            public long Id { get; set; }
            public long TargetCurrencyId { get; set; }
            public string TargetCurrencyName { get; set; } = string.Empty;
            public decimal Rate { get; set; }
        }
    }
}