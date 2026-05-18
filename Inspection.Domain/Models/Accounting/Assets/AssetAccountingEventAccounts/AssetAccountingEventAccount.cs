using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts
{
    public class AssetAccountingEventAccount : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public long AssetAccountingEventId { get; private set; }
        public AssetAccountingEvent AssetAccountingEvent { get; private set; }
        public string DebitAccountRole { get; private set; } = string.Empty;
        public string CreditAccountRole { get; private set; } = string.Empty;
        public string AmountSource { get; private set; } = string.Empty;
        public bool Disabled { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}
