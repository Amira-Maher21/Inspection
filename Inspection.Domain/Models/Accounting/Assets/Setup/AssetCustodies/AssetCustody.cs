using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCustody;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies
{
    public class AssetCustody : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public string? DocumentNumber { get; private set; }
        public DateTime DocumentDate { get; private set; }
        public string? Notes { get; private set; }

        public AssetCustodyDocumentStatus DocumentStatus { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public virtual ICollection<AssetCustodyLine> AssetCustodyLines { get; set; } = null!;

    }
}
