using Inspection.Domain.Enums.DMS.DocumentEnums;
using Inspection.Domain.Models.DMS.Folders;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.DMS.Documents
{
    public class Document : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        // Document Identity
        public string DocumentNumber { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        // File Information
        public string OriginalFilename { get; private set; } = string.Empty;
        public string FileExtension { get; private set; } = string.Empty;
        public string MimeType { get; private set; } = string.Empty;
        public long FileSize { get; private set; }
        public string FileHash { get; private set; } = string.Empty;

        // Storage
        public StorageType StorageType { get; private set; } = StorageType.Local;

        public string? URL { get; private set; } // used when StorageType = Link
        public string StoragePath { get; private set; } = string.Empty;
        public string? StorageBucket { get; private set; }

        // Folder Relation
        public long? FolderId { get; private set; }
        public Folder? Folder { get; private set; }

        // Document Metadata
        public DateTime? DocumentDate { get; private set; }

        // Versioning
        public int VersionNumber { get; private set; } = 1;
        public bool IsLatestVersion { get; private set; } = true;

        public long? ParentDocumentId { get; private set; }

        //public long? TagId { get; private set; }
        //public Tag? Tag { get; private set; }

        public ICollection<DocumentTag> DocumentTags { get; private set; } = new List<DocumentTag>();

        // Search & Analytics
        public string? SearchableContent { get; private set; }

        public int ViewCount { get; private set; } = 0;
        public int DownloadCount { get; private set; } = 0;
        public int ShareCount { get; private set; } = 0;

        public DateTime? LastAccessedAt { get; private set; } = DateTime.UtcNow;
        public long? LastAccessedById { get; set; }
        public List<DocumentEntityLink> DocumentEntityLinks { get; set; } = new List<DocumentEntityLink>();


        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}