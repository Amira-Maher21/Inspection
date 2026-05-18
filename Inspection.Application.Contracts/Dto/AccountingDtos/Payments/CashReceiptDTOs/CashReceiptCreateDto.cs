using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptLineDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.SalesInvoiceAllocationDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs
{
    public class CashReceiptCreateDto
    {
        public long CompanyId { get; set; }
        public string? ManualNumber { get; set; }
        public long BranchId { get; set; }
        public long FiscalYearId { get; set; }
        public long AccountId { get; set; }
        public long CustomerId { get; set; }
        public long CurrencyId { get; set; }
        public string? Description { get; set; }
        public string? ReceivedFrom { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime PostingDate { get; set; }
        public long? TaxTypeId { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public List<CashReceiptLineCreateDto> CashReceiptLines { get; set; } = new();
        public List<CashReceiptAdjustmentCreateDto> CashReceiptAdjustments { get; set; } = new();
        public List<SalesInvoiceAllocationCreateDto> SalesInvoiceAllocations { get; set; } = new();
    }
}
