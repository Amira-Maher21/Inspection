using Inspection.Application.Contracts.Dto.SalesManagment.sales.salesOrderLines;
using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder
{
    public class UpdateSalesOrderDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;

        public string OrderNumber { get; set; } = string.Empty;
        public DateTime? OrderDate { get; set; }

        public long CustomerId { get; set; }

        public long? SalesQuotationId { get; set; }

        public long? CurrencyId { get; set; }

        public long? PaymentTermId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal Discount { get; set; }
        //public decimal? TaxAmount { get; set; }
        public long? TaxTypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? ValidUntil { get; set; }
        public long? SalespersonId { get; set; }
        public long? BranchId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public SalesOrderDocumentStatus DocumentStatus { get; set; } = SalesOrderDocumentStatus.Draft;
        public SalesOrderApprovalStatus ApprovalStatus { get; set; } = SalesOrderApprovalStatus.Initialized;
        public string DocumentStatusCancelledReason { get; set; } = string.Empty;
        public virtual ICollection<SalesOrderLinesDto> SalesOrderLines { get; set; } = new List<SalesOrderLinesDto>();
        // series related
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
