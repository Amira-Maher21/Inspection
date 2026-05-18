using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs.DebitNoteAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs.DebitNoteLineDTOs;
using Inspection.Domain.Enums.Accounting.payments.DebitNotes;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs
{
    public class DebitNoteReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string DebitNoteNumber { get; set; } = string.Empty;

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
        public DateTime DebitNoteDate { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DebitNoteAdditionalDiscountType? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public PostingEnum Posting { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public List<DebitNoteLineDto> DebitNoteLines { get; set; } = null!;
        public List<DebitNoteAdjustmentDto> DebitNoteAdjustments { get; set; } = null!;
    }
}