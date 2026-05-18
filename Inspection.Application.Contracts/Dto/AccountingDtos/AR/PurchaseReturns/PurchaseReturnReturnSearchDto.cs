using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns
{
    public class PurchaseReturnReturnSearchDto
    {
        public long Id { get; set; }
        public string ReturnNumber { get; set; } = string.Empty;

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        public long FiscalYearId { get; set; }
        public string FiscalYearCode { get; set; }

        public long? PurchaseInvoiceId { get; private set; }
        public string PurchaseInvoiceCode { get; set; }

        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCode { get; set; }

        public long ChartOfAccountId { get; set; }
        public string ChartOfAccountName { get; set; }
        public string ChartOfAccountCode { get; set; }

        public long? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseCode { get; set; }





        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }

        public string Description { get; set; }

        public DateTime ReturnDate { get; private set; }

        public string? ReturnReason { get; private set; }


        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public PostingEnum? Posting { get; set; }


        public AdditionalDiscountType? AdditionalDiscountType { get; set; }

        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }


        public ApprovalStatus ApprovalStatus { get; set; }

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
