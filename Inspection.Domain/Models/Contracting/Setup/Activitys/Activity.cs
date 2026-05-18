using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Contracting.Setup.Activitys
{
    public class Activity : IRootEntity, ITenantEntity, IAuditable
    {

        public long Id { get; private set; }

        // FK
        public long OperationId { get; private set; }
        public Operation Operation { get; private set; }
        public long WBSId { get; private set; }
        public WBS WBS { get; private set; } = null!;

        // Required Fields
        public string ActivityCode { get; private set; } = string.Empty;
        public string ActivityName { get; private set; } = string.Empty;

        // Optional Fields
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public decimal? PlannedCost { get; private set; }
        public decimal? ProgressPercent { get; private set; }



        // Multi-tenant
        public string Tenant_ID { get; set; } = string.Empty;

        public long CompanyId { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }

        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}