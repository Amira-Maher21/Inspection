using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.CreditNotes;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs
{
    public class CreditNoteUpdateDto
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }
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

        public List<CreditNoteLineUpdateDto> CreditNoteLines { get; set; } = new();
        public List<CreditNoteAdjustmentUpdateDto> CreditNoteAdjustments { get; set; } = new();
    }
}