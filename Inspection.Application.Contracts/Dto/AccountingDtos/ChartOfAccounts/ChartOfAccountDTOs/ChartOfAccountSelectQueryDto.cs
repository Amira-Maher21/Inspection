namespace Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs
{
    public class ChartOfAccountSelectQueryDto
    {
        public long Id { get; set; }
        public string AccountCode { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public long? ParentAccountId { get; set; }
        public string AccountTypeCode { get; set; } = null!;
    }
}