using Inspection.Domain.Enums.DMS.DocumentShare;
using Inspection.Domain.Models.DMS.Documents;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.DMS.DocumentShares
{
    public class DocumentShare : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public long DocumentId { get; set; }

        public long CompanyId { get; set; }

        public long SharedById { get; set; }
        public long? SharedWithId { get; set; }

        public ShareType ShareType { get; set; }

        public string? ShareToken { get; set; }

        public string? Email { get; set; }

        public bool CanView { get; set; } = true;
        public bool CanDownload { get; set; } = false;
        public bool CanEdit { get; set; } = false;

        public bool RequirePassword { get; set; } = false;
        public string? PasswordHash { get; set; }

        public DateTime? ExpiresAt { get; set; }

        public DateTime? LastAccessedAt { get; set; }

        public bool AccessCount { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public DateTime? RevokedAt { get; set; }
        public long? RevokedById { get; set; }

        #region Navigation Properties (Optional)

        public virtual Document Document { get; set; }
        public virtual User_Code SharedBy { get; set; } = null!;
        public virtual User_Code? SharedWith { get; set; }
        public virtual User_Code? RevokedBy { get; set; }



        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        #endregion
    }
}