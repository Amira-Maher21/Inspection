using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.CashPaymentAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.CashPaymentLineDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.PurchaseInvoiceAllocationDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs
{
    public class CashPaymentCreateDto
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

        public List<CashPaymentLineCreateDto> CashPaymentLines { get; set; } = new();
        public List<CashPaymentAdjustmentCreateDto> CashPaymentAdjustments { get; set; } = new();
        public List<PurchaseInvoiceAllocationCreateDto> PurchaseInvoiceAllocations { get; set; } = new();
    }
}
