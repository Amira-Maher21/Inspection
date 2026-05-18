namespace Inspection.Application.Contracts.Dto.DMSDTOs.FolderPermissionDTOs
{
    public class FolderPermissionUpdateDto
    {
        public long Id { get; set; }
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
        public long? UserGroupId { get; set; }
    }
}