namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing
{
    public class CashUpdateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public long? CurrencyId { get; set; }
        public long CashOnHandAccountId { get; set; }
    }
}
