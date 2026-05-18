using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations
{
    public class AssetLocation : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long? ParentLocationId { get; private set; }
        public AssetLocation? ParentLocation { get; private set; }
        public ICollection<AssetLocation> Children { get; set; } = new List<AssetLocation>();

        public string LocationCode { get; private set; } = string.Empty;
        public string LocationName { get; private set; } = string.Empty;
        public bool IsLeaf { get; set; } = true;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
