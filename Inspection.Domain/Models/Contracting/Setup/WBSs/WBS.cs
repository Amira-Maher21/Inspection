using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Contracting.Setup.WBSs
{

    public class WBS : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        // FK
        public long OperationId { get; set; }
        public Operation Operation { get; set; }

        public long? ParentWBSId { get; set; }


        // Required Fields
        public string WBSCode { get; set; } = string.Empty;
        public string WBSName { get; set; } = string.Empty;

        public int LevelNo { get; set; }

        public bool IsLeaf { get; set; }


        // Multi-tenant
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }

        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}