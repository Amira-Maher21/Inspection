namespace Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs
{
    public class SCurrencyExchangeRateUpdateDto
    {
        public long Id { get; set; }
        public long BaseCurrencyId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public IEnumerable<SCurrencyExchangeRateUpdateLine> Lines { get; set; } = new List<SCurrencyExchangeRateUpdateLine>();

        public class SCurrencyExchangeRateUpdateLine
        {
            public long Id { get; set; }
            public long TargetCurrencyId { get; set; }
            public decimal Rate { get; set; }

        }
    }
}