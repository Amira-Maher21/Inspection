using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;


namespace Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups
{
    public class AssetGroup : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long AssetCategoryId { get; private set; }
        public AssetCategory AssetCategory { get; private set; } = null!;

        public string? GroupCode { get; private set; }
        public string? GroupName { get; private set; }
        public bool IsLeaf { get; private set; } = false;
        public string? Notes { get; private set; }= string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}