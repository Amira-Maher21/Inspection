namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing
{
    public class CashReturnSearchDto
    {
        public long Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

        // Branch
        public long BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        // Currency
        public long? CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public string? CurrencyName { get; set; }

        // Chart Of Account
        public long CashOnHandAccountId { get; set; }
        public string CashAccountCode { get; set; } = string.Empty;
        public string CashAccountName { get; set; } = string.Empty;


    }
}
