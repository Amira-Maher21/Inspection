using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNoteLines
{
    public class DeliveryNoteLineCreateDto
    {


        public long ItemId { get; set; }

        public long UnitOfMeasureId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? Cost { get; set; }

        public int? TaxTypeId { get; set; }

        public decimal? TaxRate { get; set; }
        public bool IsInclusive { get; set; }
        public decimal? TaxAmount { get; set; }

        public DiscountType? DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? DiscountAmount { get; set; }

        public int? WarehouseId { get; set; }

        public long? WarehouseLocationId { get; set; }

        public bool FreeItem { get; set; }
        public string? Notes { get; set; }

        public long? CostCenterId { get; set; }

        public long? CostUnitId { get; set; }

        public long? OperationId { get; set; }


        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }


    }

}
