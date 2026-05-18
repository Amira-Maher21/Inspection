using Inspection.Domain.Enums.DMS.FolderEnums;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.DMS.Folders
{
    public class Folder : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public long? ParentFolderId { get; set; }
        public string Path { get; set; } = string.Empty;
        public FolderType FolderType { get; set; } = FolderType.Standard;

        public string? ScreenId { get; private set; }
        public Screen_Code Screen { get; private set; } = null!;

        public long? LinkedEntityId { get; private set; }

        public bool IsPublic { get; private set; } = false;
        public bool InheritPermissions { get; private set; } = true;
        public PermissionType PermissionType { get; private set; }
        public string Icon { get; private set; } = "Folder";
        public string Color { get; private set; } = "#FFA500";
        public long SortOrder { get; private set; } = 0;
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}