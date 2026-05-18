using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices
{
    public class SalesInvoiceReturnSearchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public string InvoiceNo { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime PaymentDuesDate { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerCode { get; set; } = string.Empty;



        public long BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;


        public long? SalesOrderId { get; set; }
        public string? SalesOrderCode { get; set; }
        public string? SalesOrderName { get; set; }

        public long? GoodsReceiptId { get; set; }
        public string? GoodsReceiptName { get; set; }
        public string? GoodsReceiptCode { get; set; }

        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;

        public long PaymentTermsId { get; set; }
        public string PaymentTermsName { get; set; } = string.Empty;
        public string PaymentTermsCode { get; set; } = string.Empty;


        public SalesInvoiceDocumentStatus DocumentStatus { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public bool IsPosted { get; set; }

        // Amounts
        public decimal TotalAmount { get; set; }
        public decimal? TaxAmount { get; set; }

        // Notes
        public string? Notes { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public long? WarehouseId { get; set; }
        public long? SalesPersonId { get; set; }

        public decimal NetAmount { get; set; }

        public PostingEnum? Posting { get; set; }
        public string? CustomersPurchaseOrder { get; set; }
        public string? CustomersPurchaseOrderDate { get; set; }

        public AdditionalDiscountType? AdditionalDiscountType { get; set; }
        public ShipmentStatus? ShipmentStatus { get; set; }
        public ShipmentMethod? ShipmentMethod { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? ShipmentAmount { get; set; }
        public string? ShipmentAddress { get; set; }

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