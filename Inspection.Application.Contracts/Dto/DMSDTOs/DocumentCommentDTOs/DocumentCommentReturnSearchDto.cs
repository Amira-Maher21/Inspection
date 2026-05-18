namespace Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs
{
    public class DocumentCommentReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public bool IsResolved { get; set; } = false;
        public long? ParentCommentId { get; set; }

        public long DocumentId { get; set; }
        public string DocumentDescription { get; set; } = string.Empty;
        public string DocumentTitle { get; set; } = string.Empty;

        public long UserId { get; set; }
        public string UserCode { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public long? ResolvedById { get; set; }
        public string? ResolvedByCode { get; set; }
        public string? ResolvedByName { get; set; }

        public DateTime? ResolvedAt { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
