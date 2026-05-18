using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes
{
    public class DeliveryNoteImportTemplateDto
    {
        public string CompanyId { get; set; }

        public string BranchCode { get; set; }

        public string DeliveryNoteNo { get; set; } = string.Empty;

        public DateTime DeliveryNoteDate { get; set; }

        public string CustomerCode { get; set; }

        public string? WarehouseCode { get; set; }

        public string? SalesOrderCode { get; set; }

        public string? SalesInvoiceCode { get; set; }

        public string CurrencyCode { get; set; }

        public string PaymentTermsCode { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal? TaxAmount { get; set; }

        public string? Notes { get; set; }

        public PostingEnum? Posting { get; set; }

        public string? CustomerPurchaseOrder { get; set; }

        public string? CustomerPurchaseOrderDate { get; set; }
        public string DeliveryPersonName { get; set; }

        // Discounts & Shipment
        public AdditionalDiscountType? AdditionalDiscountType { get; set; }

        public decimal? AdditionalDiscountValue { get; set; }

        public decimal? AdditionalDiscountAmount { get; set; }

        public decimal? TotalDiscount { get; set; }

        public decimal? ShipmentAmount { get; set; }

        public string? ShipmentAddress { get; set; }

        public ShipmentStatus? ShipmentStatus { get; set; }

        public ShipmentMethod? ShipmentMethod { get; set; }
    }
}