using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs;
using Inspection.Domain.Enums.DMS.DocumentEnums;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs
{
    public class DocumentDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string OriginalFilename { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string FileHash { get; set; } = string.Empty;
        public StorageType StorageType { get; set; } = StorageType.Local;
        public string? URL { get; set; }
        public string StoragePath { get; set; } = string.Empty;
        public string? StorageBucket { get; set; }
        public long? FolderId { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int VersionNumber { get; set; } = 1;
        public bool IsLatestVersion { get; set; } = true;
        public long? ParentDocumentId { get; set; }

        public List<long> TagIds { get; set; } = new List<long>();

        public string? SearchableContent { get; set; }
        public int ViewCount { get; set; } = 0;
        public int DownloadCount { get; set; } = 0;
        public int ShareCount { get; set; } = 0;
        public DateTime? LastAccessedAt { get; set; } = DateTime.UtcNow;
        public long? LastAccessedById { get; set; }
        public List<DocumentEntityLinkDto> DocumentEntityLinks { get; set; } = new List<DocumentEntityLinkDto>();

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}