using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices.PurchaseInvoiceAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices.PurchaseInvoiceLines;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices
{
    public class PurchaseInvoiceDto
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;

        public long BranchId { get; set; }

        public long? WarehouseId { get; set; }

        public long SupplierId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public long? SalesOrderId { get; set; }

        public long CurrencyId { get; set; }

        public long PaymentTermId { get; set; }

        public long? SalesPersonId { get; set; }


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


        public ICollection<PurchaseInvoiceLineDto> InvoiceLines { get; set; } = new List<PurchaseInvoiceLineDto>();
        public ICollection<PurchaseInvoiceAdjustmentDto> Adjustments { get; set; } = new List<PurchaseInvoiceAdjustmentDto>();
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
