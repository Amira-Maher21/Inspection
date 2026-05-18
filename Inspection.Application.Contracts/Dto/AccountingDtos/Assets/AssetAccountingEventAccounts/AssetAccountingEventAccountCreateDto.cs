namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEventAccounts
{
    public class AssetAccountingEventAccountCreateDto
    {
        public long AssetAccountingEventId { get; set; }
        public string DebitAccountRole { get; set; } = string.Empty;
        public string CreditAccountRole { get; set; } = string.Empty;
        public string AmountSource { get; set; } = string.Empty;
        public bool Disabled { get; set; }

    }
}
