using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs.SalesQuotationLineDTOs;
using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs
{
    public class SalesQuotationDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;

        public string QuotationNumber { get; set; } = string.Empty;

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
        public List<SalesQuotationLineDto> SalesQuotationLines { get; set; } = new();

        // series related
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
