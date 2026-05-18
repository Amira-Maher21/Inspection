using Inspection.Domain.Enums.Accounting.Assets.TransactionTypes;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions
{
    public class AssetTransactionImportTemplateDto
    {
        public long FixedAssetCode { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }
        public long? ReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public string Notes { get; set; }
    }
}
