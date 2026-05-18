using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.FixedAssets
{
    public class AssetDepreciationSchedule : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public long AssetId { get; private set; }
        public FixedAsset FixedAsset { get; private set; } = null!;
        public int PeriodYear { get; private set; }
        public int PeriodMonth { get; private set; }
        public decimal DepreciationAmount { get; private set; }
        public bool IsPosted { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}
