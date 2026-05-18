using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments
{
    public class ModeOfPaymentUpdateDto
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


    }
}

