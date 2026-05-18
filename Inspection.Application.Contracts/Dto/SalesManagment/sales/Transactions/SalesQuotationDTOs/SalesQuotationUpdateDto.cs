using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs.SalesQuotationLineDTOs;
using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs
{
    public class SalesQuotationUpdateDto
    {
        public long Id { get; set; }
        public string CompanyId { get; set; } = string.Empty;

        public long CustomerId { get; set; }
        public long? InspectionRequestId { get; set; }
        public long? SalespersonId { get; set; }
        public long? TaxTypeId { get; set; }
        public long? CurrencyId { get; set; }

        public DateTime? QuotationDate { get; set; }
        public string VersionNumber { get; set; } = string.Empty;
        public DateTime? ValidUntil { get; set; }
        public string PONumber { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string TermsAndConditions { get; set; } = string.Empty;
        public string CustomerNote { get; set; } = string.Empty;

        public SalesQuotationDocumentStatus DocumentStatus { get; set; } = SalesQuotationDocumentStatus.Draft;
        public SalesQuotationStatus ApprovalStatus { get; set; }
        public string DocumentStatusCancelled { get; set; } = string.Empty;
        public string DocumentStatusDeclined { get; set; } = string.Empty;
        public List<SalesQuotationLineUpdateDto> SalesQuotationLines { get; set; } = new();
    }
}