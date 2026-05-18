namespace Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs
{
    public class SCurrencyExchangeRateUpdateLineDto
    {
        public long Id { get; set; }
        public long CurrencyExchangId { get; set; }
        public long TargetCurrencyId { get; set; }
        public decimal Rate { get; set; }
    }
}