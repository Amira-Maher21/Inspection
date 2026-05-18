using Inspection.Domain.Models.DMS.Folders;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.DMS.FolderPermissions
{
    public class FolderPermission : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public bool CanView { get; private set; } = false;
        public bool CanDownload { get; private set; } = false;
        public bool CanUpload { get; private set; } = false;
        public bool CanEdit { get; private set; } = false;
        public bool CanDelete { get; private set; } = false;
        public bool CanShare { get; private set; } = false;
        public bool CanManage { get; private set; } = false;
        public DateTime? ValidFrom { get; private set; }
        public DateTime? ValidUntil { get; private set; }

        public long FolderId { get; private set; }
        public Folder Folder { get; private set; } = null!;

        public long? UserGroupId { get; private set; }
        public User_Group UserGroup { get; private set; } = null!;

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}