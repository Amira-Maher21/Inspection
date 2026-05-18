using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.CashPaymentAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.CashPaymentLineDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.PurchaseInvoiceAllocationDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs
{
    public class CashPaymentReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public string? ManualNumber { get; set; }

        public long BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public long FiscalYearId { get; set; }
        public string FiscalYearCode { get; set; } = string.Empty;

        public long AccountId { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;

        public long CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public long CurrencyId { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string CurrencyName { get; set; } = string.Empty;

        public long? TaxTypeId { get; set; }
        public string? TaxTypeCode { get; set; }
        public string? TaxTypeName { get; set; }

        public string? Description { get; set; }
        public string? ReceivedFrom { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public List<CashPaymentLineDto> CashPaymentLines { get; set; } = new();
        public List<CashPaymentAdjustmentDto> CashPaymentAdjustments { get; set; } = new();
        public List<PurchaseInvoiceAllocationDto> PurchaseInvoiceAllocations { get; set; } = new();
    }
}