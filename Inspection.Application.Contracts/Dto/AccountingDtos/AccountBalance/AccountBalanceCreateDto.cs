using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountBalance
{
    public class AccountBalanceCreateDto
    {
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public long ChartOfAccountId { get; set; }
    }
}