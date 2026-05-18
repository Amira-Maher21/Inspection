using Inspection.Domain.Enums.Accounting.Assets.TransactionTypes;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.AssetTransactions
{
    public class AssetTransaction : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public long FixedAssetId { get; set; }
        public FixedAsset FixedAsset { get; private set; } = null!;
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
