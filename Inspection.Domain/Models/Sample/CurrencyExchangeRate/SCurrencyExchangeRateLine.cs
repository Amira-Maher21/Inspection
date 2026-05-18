using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Sample.CurrencyExchangeRate
{
    public class SCurrencyExchangeRateLine : IAuditable
    {
        // Business Properties
        public long Id { get; set; }
        public long CurrencyExchangHeaderId { get; set; }
        public long TargetCurrencyId { get; set; }
        public decimal Rate { get; set; }

        // Auditable Properties
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Navigation Properties
        public Currency Currency { get; set; } = null!;
    }
}
