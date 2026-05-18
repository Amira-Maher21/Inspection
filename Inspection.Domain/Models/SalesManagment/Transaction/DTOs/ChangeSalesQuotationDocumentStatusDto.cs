using Inspection.Domain.Enums;

namespace Inspection.Domain.Models.SalesManagment.Transaction.DTOs
{
    public class ChangeSalesQuotationDocumentStatusDto
    {
        public long RequestId { get; set; }
        public SalesQuotationDocumentStatus DocumentStatus { get; set; }
        public string? CancelledDescription { get; set; }
    }
}
