using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.CreditNotes;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs
{
    public class CreditNoteDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string CreditNoteNumber { get; set; } = string.Empty;
        public long BranchId { get; set; }
        public long FiscalYearId { get; set; }
        public long? SalesInvoiceId { get; set; }
        public long CustomerId { get; set; }
        public long ChartOfAccountId { get; set; }
        public long CurrencyId { get; set; }
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