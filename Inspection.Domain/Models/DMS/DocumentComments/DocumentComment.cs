using Inspection.Domain.Models.DMS.Documents;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.DMS.DocumentComments
{
    public class DocumentComment : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public string CommentText { get; private set; } = string.Empty;
        public bool IsResolved { get; private set; } = false;
        public long? ParentCommentId { get; private set; }
        public long DocumentId { get; private set; }
        public Document Document { get; private set; } = null!;
        public long UserId { get; private set; }
        public User_Code User_Code { get; private set; } = null!;
        public long? ResolvedById { get; private set; }
        public User_Code? ResolvedBy { get; private set; } = null!;
        public DateTime? ResolvedAt { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}