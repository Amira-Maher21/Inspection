using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceLines;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesPersons;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices
{
    public class SalesInvoiceDto
    {
        public long Id { get; private set; }
        public string InvoiceNo { get; set; } = string.Empty;

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

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




        // Series
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }


        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public ICollection<SalesInvoiceLineDto> SalesInvoiceLines { get; set; } = new List<SalesInvoiceLineDto>();
        public ICollection<SalesInvoiceSalesAdjustmentDto> SalesInvoiceSalesAdjustments { get; set; } = new List<SalesInvoiceSalesAdjustmentDto>();
        public ICollection<SalesInvoiceSalesPersonDto> SalesInvoiceSalesPersons { get; set; } = new List<SalesInvoiceSalesPersonDto>();









    }

}
