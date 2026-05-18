using Inspection.Domain.Models.DMS.Tags;

namespace Inspection.Domain.Models.DMS.Documents
{
    public class DocumentTag
    {
        public long DocumentId { get; set; }
        public Document Document { get; set; } = null!;

        public long TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
