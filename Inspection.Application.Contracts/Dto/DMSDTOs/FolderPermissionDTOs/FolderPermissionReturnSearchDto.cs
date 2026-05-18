namespace Inspection.Application.Contracts.Dto.DMSDTOs.FolderPermissionDTOs
{
    public class FolderPermissionReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public bool CanView { get; set; } = false;
        public bool CanDownload { get; set; } = false;
        public bool CanUpload { get; set; } = false;
        public bool CanEdit { get; set; } = false;
        public bool CanDelete { get; set; } = false;
        public bool CanShare { get; set; } = false;
        public bool CanManage { get; set; } = false;
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }

        public long FolderId { get; set; }
        public string FolderName { get; set; } = string.Empty;

        public long? UserGroupId { get; set; }
        public string? UserGroupName { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}