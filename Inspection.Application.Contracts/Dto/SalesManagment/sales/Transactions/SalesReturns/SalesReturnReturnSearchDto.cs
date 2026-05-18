using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns
{
    public class SalesReturnReturnSearchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; }
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        public long FiscalYearId { get; set; }
        public string FiscalYearCode { get; set; }

        public string ReturnNumber { get; set; }

        public long? SalesInvoiceId { get; set; }
        public string SalesInvoiceCode { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }

        public long ChartOfAccountId { get; set; }
        public string ChartOfAccounName { get; set; }
        public string ChartOfAccounCode { get; set; }

        public long WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseCode { get; set; }


        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }


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

        // Series
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
