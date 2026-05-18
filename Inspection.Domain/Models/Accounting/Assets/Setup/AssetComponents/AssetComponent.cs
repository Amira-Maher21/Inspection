using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories
{
    public class AssetComponent : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public long CompanyId { get; private set; }

        public string Tenant_ID { get; set; } = string.Empty;

        public long FixedAssetId { get; private set; }
        public FixedAsset FixedAsset { get; private set; } = null!;
        public string ComponentName { get; private set; } = string.Empty;
        public decimal ComponentCost { get; private set; }
        public int UsefulLifeMonths { get; private set; }
        public decimal ResidualValue { get; private set; }

        public long DepreciationMethodId { get; private set; }
        //public DepreciationMethod DepreciationMethod { get; private set; }

        public string? Notes { get; private set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}