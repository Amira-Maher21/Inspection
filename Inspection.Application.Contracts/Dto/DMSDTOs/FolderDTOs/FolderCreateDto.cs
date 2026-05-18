using Inspection.Domain.Enums.DMS.FolderEnums;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.FolderDTOs
{
    public class FolderCreateDto
    {
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
    }
}