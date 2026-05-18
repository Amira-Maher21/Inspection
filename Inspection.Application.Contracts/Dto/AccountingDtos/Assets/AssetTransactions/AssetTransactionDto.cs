using Inspection.Domain.Enums.Accounting.Assets.TransactionTypes;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions
{
    public class AssetTransactionDto
    {
        public long Id { get; set; }
        public long FixedAssetId { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }
        public long? ReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public string Notes { get; set; }



        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
