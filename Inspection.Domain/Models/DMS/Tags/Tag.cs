using Inspection.Domain.Models.DMS.Documents;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.DMS.Tags
{
    public class Tag : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Color { get; private set; } = "#808080";

        // MANY-TO-MANY RELATION WITH DOCUMENT
        public ICollection<DocumentTag> DocumentTags { get; private set; } = new List<DocumentTag>();

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}