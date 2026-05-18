namespace Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs
{
    public class SCurrencyExchangeRateCreateDto
    {
        public long BaseCurrencyId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public IEnumerable<SCurrencyExchangeRateCreateLine> Lines { get; set; } = new List<SCurrencyExchangeRateCreateLine>();

        public class SCurrencyExchangeRateCreateLine
        {
            public long TargetCurrencyId { get; set; }
            public decimal Rate { get; set; }
        }
    }
}