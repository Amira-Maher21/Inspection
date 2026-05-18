using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices
{
    public class SalesInvoiceImportTemplateDto
    {
        public long CompanyId { get; set; }

        public string BranchCode { get; set; } = string.Empty;
        public string? WarehouseCode { get; set; }

        public string CustomerCode { get; set; } = string.Empty;

        public DateTime InvoiceDate { get; set; }

        public string? SalesOrderCode { get; set; }

        public string CurrencyCode { get; set; } = string.Empty;

        public string PaymentTermsCode { get; set; } = string.Empty;

        public string? SalesPersonCode { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }

        public DateTime PaymentDuesDate { get; set; } // ✅ fix name

        public string? Notes { get; set; }

        public PostingEnum? Posting { get; set; }

        public string? CustomersPurchaseOrder { get; set; }
        public DateTime? CustomersPurchaseOrderDate { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
