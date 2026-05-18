using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Models.SystemConfigurations.DetailTables;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates
{
    public class CurrencyExchangRate : IRootEntity, ITenantEntity, IAuditable
    {
        public string Tenant_ID { get; set; } = string.Empty;
        public long Id { get; set; }
        public long CurrencyId { get; set; }
        public long CompanyId { get; set; }
        public Currency Currency { get; set; } = null!;

        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<DetailTable> Details { get; set; } = new List<DetailTable>();
        private CurrencyExchangRate() { }

    }
}
