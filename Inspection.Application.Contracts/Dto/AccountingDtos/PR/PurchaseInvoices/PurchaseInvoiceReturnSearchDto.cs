using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices
{

    public class PurchaseInvoiceReturnSearchDto
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;

        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        public long? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseCode { get; set; }

        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCode { get; set; }

        public DateTime InvoiceDate { get; set; }

        public long? SalesOrderId { get; set; }
        public string? SalesOrderCode { get; set; }

        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }

        public long PaymentTermId { get; set; }
        public string PaymentTermName { get; set; }
        public string PaymentTermCode { get; set; }

        public long? SalesPersonId { get; set; }
        public string? SalesPersonName { get; set; }
        public string? SalesPersonCode { get; set; }


        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public AdditionalDiscountType? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? ShipmentAmount { get; set; }
        public string? ShipmentAddress { get; set; }
        public ShipmentStatus? ShipmentStatus { get; set; }
        public ShipmentMethod? ShipmentMethod { get; set; }
        public decimal? TotalDiscount { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
        public DocumentStatus Status { get; set; }


        //public ICollection<PurchaseInvoiceLineDto> InvoiceLines { get; set; } = new List<PurchaseInvoiceLineDto>();
        //public ICollection<PurchaseInvoiceAdjustment> Adjustments { get; set; } = new List<PurchaseInvoiceAdjustment>();


        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }








    }

}
