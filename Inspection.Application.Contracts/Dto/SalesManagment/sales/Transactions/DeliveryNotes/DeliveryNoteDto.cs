using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNoteLines;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes
{
    public class DeliveryNoteDto
    {
        public long Id { get; set; }
        public string DeliveryNoteNo { get; set; }
        public long CompanyId { get; set; }

        public long BranchId { get; set; }

        public long? WarehouseId { get; set; }

        public long CustomerId { get; set; }


        public DateTime DeliveryNoteDate { get; set; }


        public long? SalesOrderId { get; set; }
        public long? SalesInvoiceId { get; set; }


        public long CurrencyId { get; set; }

        public long PaymentTermId { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public string Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public string CustomerPurchaseOrder { get; set; }
        public DateTime? CustomerPurchaseOrderDate { get; set; }

        public AdditionalDiscountType? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? ShipmentAmount { get; set; }

        public string ShipmentAddress { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        public ShipmentMethod ShipmentMethod { get; set; }
        public string DeliveryPersonName { get; set; }


        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        public virtual List<DeliveryNoteLineDto> DeliveryNoteLines { get; set; } = new List<DeliveryNoteLineDto>();


        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
