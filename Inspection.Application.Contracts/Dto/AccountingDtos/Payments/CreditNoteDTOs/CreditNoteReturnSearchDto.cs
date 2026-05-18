using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.CreditNotes;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs
{
    public class CreditNoteReturnSearchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string CreditNoteNumber { get; set; } = string.Empty;

        public long BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public long FiscalYearId { get; set; }
        public string FiscalYearCode { get; set; } = string.Empty;

        public long? SalesInvoiceId { get; set; }
        public string? InvoiceNumber { get; set; } = string.Empty;

        public long CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public long ChartOfAccountId { get; set; }
        public string ChartOfAccountCode { get; set; } = string.Empty;
        public string ChartOfAccountName { get; set; } = string.Empty;

        public long CurrencyId { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string CurrencyName { get; set; } = string.Empty;

        public string? Description { get; set; }
        public DateTime CreditNoteDate { get; set; }
        public CreditNoteAdditionalDiscountType? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public PostingEnum Posting { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public List<CreditNoteLineDto> CreditNoteLines { get; set; } = new();
        public List<CreditNoteAdjustmentDto> CreditNoteAdjustments { get; set; } = new();
    }
}