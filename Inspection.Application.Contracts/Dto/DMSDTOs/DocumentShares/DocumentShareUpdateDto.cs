using Inspection.Domain.Enums.DMS.DocumentShare;

namespace Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares
{
    public class DocumentShareUpdateDto
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



    }
}
