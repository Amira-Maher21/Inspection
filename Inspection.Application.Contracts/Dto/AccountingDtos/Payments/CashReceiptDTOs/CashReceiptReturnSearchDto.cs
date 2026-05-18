using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptLineDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.SalesInvoiceAllocationDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs
{
    public class CashReceiptReturnSearchDto
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

        public List<CashReceiptLineDto> CashReceiptLines { get; set; } = new();
        public List<CashReceiptAdjustmentDto> CashReceiptAdjustments { get; set; } = new();
        public List<SalesInvoiceAllocationDto> SalesInvoiceAllocations { get; set; } = new();
    }
}