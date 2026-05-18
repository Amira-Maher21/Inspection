namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs
{
    public class AccountingPeriodDto
    {

        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public long FiscalYearId { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LockDate { get; set; }
        public bool IsClosed { get; set; } = true;

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }


}