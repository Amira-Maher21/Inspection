namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs
{
    public class FiscalYearUpdateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
