using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SystemConfigurations.Currencies
{
    public class Currency : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        public string Tenant_ID { get; set; } = string.Empty;

        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        public string? Sub_Currency { get; private set; }

        public string CurrencySymbol { get; private set; } = string.Empty;



        public bool Disabled { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}