using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices.PurchaseInvoiceAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices.PurchaseInvoiceLines;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices
{
    public class PurchaseInvoiceUpdateDto
    {
        public long Id { get; set; }

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

        public long CompanyId { get; set; }

        public ICollection<PurchaseInvoiceLineUpdateDto> InvoiceLines { get; set; } = new List<PurchaseInvoiceLineUpdateDto>();
        public ICollection<PurchaseInvoiceAdjustmentUpdateDto> Adjustments { get; set; } = new List<PurchaseInvoiceAdjustmentUpdateDto>();




    }
}
