using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments
{
    public class ModeOfPayment : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ChartOfAccountId { get; set; }
        public ChartOfAccount ChartOfAccount { get; set; }
        public long? CurrencyId { get; set; }
        public Currency? Currency { get; set; }
        public string Description { get; set; }
        public PaymentType PaymentType { get; set; }

        public FeeType? FeeType { get; set; }
        public long? FeesAccountId { get; set; }
        public ChartOfAccount? FeesAccount { get; set; }
        public Direction Direction { get; set; }
        public decimal? FeeValue { get; set; }
        public bool? HasFee { get; set; }
        public bool IncludeInPOS { get; set; } = false;
        public string Tenant_ID { get; set; } = string.Empty;


        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
