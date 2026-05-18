using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns.PurchaseReturnAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns.PurchaseReturnLines;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns
{
    public class PurchaseReturnUpdateDto
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }

        public long BranchId { get; set; }

        public long FiscalYearId { get; set; }

        public string ReturnNumber { get; set; } = string.Empty;

        public long? PurchaseInvoiceId { get; set; }

        public long SupplierId { get; set; }

        public long ChartOfAccountId { get; set; }

        public long WarehouseId { get; set; }

        public long CurrencyId { get; set; }
        public string? Description { get; set; }

        public DateTime ReturnDate { get; set; }

        public string? ReturnReason { get; set; }

        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public AdditionalDiscountType? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }

        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }



        public List<PurchaseReturnLineUpdateDto> PurchaseReturnLines { get; set; } = new();
        public List<PurchaseReturnAdjustmentUpdateDto> PurchaseReturnAdjustments { get; set; } = new();


    }
}
