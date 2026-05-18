using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceLines
{
    public class SalesInvoiceLineDto
    {
        public long Id { get; set; }

        public long SalesInvoiceId { get; set; }

        public long? ItemId { get; set; }
        public long UnitOfMeasureId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal? Cost { get; set; }

        public decimal? TaxRate { get; set; }

        public long? WarehouseLocationId { get; set; }

        public long? WarehouseId { get; set; }

        public long? TaxTypeId { get; set; }
        public bool? IsInclusive { get; set; }
        public decimal? TaxAmount { get; set; }
        public DiscountType? DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? DiscountAmount { get; set; }

        public long? TaxTypeId2 { get; set; }
        public decimal? TaxRate2 { get; set; }
        public bool? IsInclusive2 { get; set; }
        public decimal? TaxAmount2 { get; set; }

        public bool? FreeItem { get; set; }
        public string Notes { get; set; } = string.Empty;


        public long? CostCentertId { get; set; }

        public long? CostUnitId { get; set; }

        public long? OperationId { get; set; }

        public long? WBSId { get; set; }

        public long? CostCode { get; set; }
        public long? ActivityId { get; set; }

        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }
        public LineTypeEnum? LineType { get; private set; }
        public long? AssetId { get; private set; }
        public AssetTransactionTypeEnum? AssetTransactionType { get; private set; }


        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
