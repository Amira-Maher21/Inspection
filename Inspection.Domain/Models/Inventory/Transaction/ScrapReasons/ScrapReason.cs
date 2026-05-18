using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.Transaction.ScrapReasons
{
    public class ScrapReason : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; }
        public long CompanyId { get; private set; }

        public string Code { get; private set; }
        public string Name { get; private set; }

        public long ChartOfAccountId { get; private set; }
        public ChartOfAccount ChartOfAccount { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
