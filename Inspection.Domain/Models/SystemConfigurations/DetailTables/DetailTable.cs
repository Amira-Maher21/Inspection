using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.SystemConfigurations.DetailTables
{
    public class DetailTable : IRootEntity, IAuditable
    {
        public long Id { get; set; }

        public long CurrencyExchangRateId { get; set; }
        public CurrencyExchangRate CurrencyExchangRate { get; set; } = null!;
        public long CurrencyId { get; set; }
        public Currency Currencys { get; set; } = null!;

        public decimal Rate { get; set; }


        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}

