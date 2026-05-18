using Inspection.Domain.Enums.Contracting.Setup.BOQs;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Contracting.Setup.BOQs
{
    public class BOQ : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        // Relations
        public long OperationId { get; private set; }
        public Operation Operation { get; private set; } = null!;

        public string BOQNumber { get; private set; } = string.Empty;
        public float RevisionNumber { get; private set; }
        public BOQDocumentStatus DocumentStatus { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        //Details
        public virtual ICollection<BOQLine> BOQLines { get; set; } = null!;

    }
}