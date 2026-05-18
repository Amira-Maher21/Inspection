using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Domain.Models.Accounting.PostingEngine
{
    public class PostingDocumentType
    {
        public long Id { get; set; }
        public string DocumentCode { get; set; } = string.Empty; 
        public string DocumentName { get; set; } = string.Empty;
        public Screen_Code Screen_Code { get; set; } = null!;
        public string? Screen_CodeId { get; set; }
    }
}
