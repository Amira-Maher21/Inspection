using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents
{
    public class AssetAccountingEvent : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string AssetEventType { get; private set; } = string.Empty;
        public string SourceModule { get; private set; } = string.Empty;
        public bool IsReversible { get; private set; }
        public bool Disabled { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}
