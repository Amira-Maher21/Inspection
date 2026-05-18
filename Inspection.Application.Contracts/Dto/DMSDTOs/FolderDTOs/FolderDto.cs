using Inspection.Domain.Enums.DMS.FolderEnums;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.FolderDTOs
{
    public class FolderDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public long? ParentFolderId { get; set; }
        public string Path { get; set; } = string.Empty;
        public FolderType FolderType { get; set; } = FolderType.Standard;
        public string? ScreenId { get; set; }
        public long? LinkedEntityId { get; set; }

        public bool IsPublic { get; set; } = false;
        public bool InheritPermissions { get; set; } = true;
        public PermissionType PermissionType { get; set; }
        public string Icon { get; set; } = "Folder";
        public string Color { get; set; } = "#FFA500";
        public long SortOrder { get; set; } = 0;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}