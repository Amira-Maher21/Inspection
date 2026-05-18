using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.AccountingSetup.Cashing
{
    public class Cash : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        //company id
        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;
        public long? CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;
        public long CashOnHandAccountId { get; private set; }
        public ChartOfAccount ChartOfAccount { get; private set; } = null!;



        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}