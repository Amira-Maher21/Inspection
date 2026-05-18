namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing
{
    public class CashDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //company id
        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long BranchId { get; set; }
        public long? CurrencyId { get; set; }
        public long CashOnHandAccountId { get; set; }



        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
