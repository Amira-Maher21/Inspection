using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments
{
    public class ModeOfPaymentSearchReturnDto
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public long ChartOfAccountId { get; set; }
        public long? CurrencyId { get; set; }
        public string Description { get; set; }
        public PaymentType PaymentType { get; set; }

        public FeeType? FeeType { get; set; }
        public long? FeesAccountId { get; set; }
        public Direction Direction { get; set; }
        public float? FeeValue { get; set; }
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

