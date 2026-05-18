using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns.SalesReturnAdjustments;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns.SalesReturnLines;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns
{
    public class SalesReturnCreateDto
    {

        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public long FiscalYearId { get; set; }


        public long? SalesInvoiceId { get; set; }
        public long CustomerId { get; set; }

        public long ChartOfAccountId { get; set; }

        public long WarehouseId { get; set; }
        public long CurrencyId { get; set; }

        public string Description { get; set; }

        public DateTime ReturnDate { get; set; }

        public string ReturnReason { get; set; }

        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public int? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }


        public List<SalesReturnLineCreateDto> SalesReturnLines { get; set; } = new();
        public List<SalesReturnAdjustmentCreateDto> SalesReturnAdjustments { get; set; } = new();



    }
}
