using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceLines;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesPersons;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices
{
    public class SalesInvoiceCreateDto
    {


        public long CompanyId { get; set; }

        public long BranchId { get; set; }

        public long? WarehouseId { get; set; }

        public long CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public long? SalesOrderId { get; set; }

        public long CurrencyId { get; set; }


        public long PaymentTermsId { get; set; }

        public long? SalesPersonId { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime PaymentDuesDate { get; set; }

        public string? Notes { get; set; }
        public PostingEnum? Posting { get; set; }
        public string? CustomersPurchaseOrder { get; set; }
        public DateTime? CustomersPurchaseOrderDate { get; set; }

        public AdditionalDiscountType? AdditionalDiscountType { get; set; }

        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? ShipmentAmount { get; set; }
        public string? ShipmentAddress { get; set; }
        public ShipmentStatus? ShipmentStatus { get; set; }
        public ShipmentMethod? ShipmentMethod { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }



        public ICollection<SalesInvoiceLineCreateDto> SalesInvoiceLines { get; set; } = new List<SalesInvoiceLineCreateDto>();
        public ICollection<SalesInvoiceSalesAdjustmentCreateDto> SalesInvoiceSalesAdjustments { get; set; } = new List<SalesInvoiceSalesAdjustmentCreateDto>();
        public ICollection<SalesInvoiceSalesPersonCreateDto> SalesInvoiceSalesPersons { get; set; } = new List<SalesInvoiceSalesPersonCreateDto>();



    }
}
