namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs
{
    public class AccountingPeriodCreateDto
    {
        public long CompanyId { get; set; }
        public long FiscalYearId { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LockDate { get; set; }
        public bool IsClosed { get; set; } = true;
    }
}
