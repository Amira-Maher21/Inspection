namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEventAccounts
{
    public class AssetAccountingEventAccountDto
    {
        public long Id { get; set; }
        public long AssetAccountingEventId { get; set; }
        public string DebitAccountRole { get; set; } = string.Empty;
        public string CreditAccountRole { get; set; } = string.Empty;
        public string AmountSource { get; set; } = string.Empty;
        public bool Disabled { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
