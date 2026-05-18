using Inspection.Domain.Enums.Accounting.Assets.TransactionTypes;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions
{
    public class AssetTransactionReturnSearchDto
    {
        public long Id { get; set; }
        public long FixedAssetId { get; set; }
        public string FixedAssetCode { get; set; } = string.Empty;
        public string FixedAssetName { get; set; } = string.Empty;
        public TransactionTypeEnum TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }
        public long? ReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public string Notes { get; set; }



        //public string Tenant_ID { get; set; } = string.Empty;

    }
}
