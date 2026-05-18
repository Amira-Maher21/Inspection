namespace Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs
{
    public class SCurrencyExchangeRateAddLineDto
    {
        public long CurrencyExchangId { get; set; }
        public long TargetCurrencyId { get; set; }
        public decimal Rate { get; set; }
    }
}