using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.PostingEngine;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountBalance
{
    public class AccountBalanceUpdateDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public long ChartOfAccountId { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}