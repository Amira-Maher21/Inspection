using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs.DebitNoteAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs.DebitNoteLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.DebitNotes;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs
{
    public class DebitNoteCreateDto
    {
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public long FiscalYearId { get; set; }
        public long? SalesInvoiceId { get; set; }
        public long CustomerId { get; set; }
        public long ChartOfAccountId { get; set; }
        public long CurrencyId { get; set; }
        public string? Description { get; set; }
        public DateTime DebitNoteDate { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DebitNoteAdditionalDiscountType? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public PostingEnum Posting { get; set; }

        public List<DebitNoteLineCreateDto> DebitNoteLines { get; set; } = null!;
        public List<DebitNoteAdjustmentCreateDto> DebitNoteAdjustments { get; set; } = null!;
    }
}