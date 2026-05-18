namespace Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs
{
    public class DocumentCommentUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public bool IsResolved { get; set; } = false;
        public long? ParentCommentId { get; set; }
        public long DocumentId { get; set; }
        public long UserId { get; set; }
        public long? ResolvedById { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}