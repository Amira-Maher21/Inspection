using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts
{
    public class
        BankAccount : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public long BankId { get; set; }
        public Bank Bank { get; set; }

        public string BankAccountNumber { get; set; }
        public string IBAN { get; set; }
        public string AccountType { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }

        public long CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public bool IsCompanyAccount { get; set; }


        public long ChartOfAccountId { get; set; }
        public ChartOfAccount ChartOfAccount { get; set; }


        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
