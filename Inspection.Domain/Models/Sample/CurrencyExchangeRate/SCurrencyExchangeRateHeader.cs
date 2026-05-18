using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Sample.CurrencyExchangeRate
{
    public class SCurrencyExchangeRateHeader : IRootEntity, ITenantEntity, IAuditable
    {
        // Business Properties
        public long Id { get; set; }
        public long BaseCurrencyId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Multi Company Property
        public long CompanyId { get; set; }

        // Multitenancy Property
        public string Tenant_ID { get; set; } = string.Empty;

        // Auditable Properties
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Navigation Properties
        public ICollection<SCurrencyExchangeRateLine>? Lines { get; set; }
        public Currency? Currency { get; set; }
    }
}