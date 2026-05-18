using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers
{
    public class InventoryLedgerDto
    {

        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long BranchId { get; set; }
        public long WarehouseId { get; set; }
        public long? WarehouseLocationId { get; set; }
        public long ItemId { get; set; }

        public long PostingDocumentTypeId { get; set; }

        public long UnitOfMeasureId { get; set; }

        public DateTime TransactionDate { get; set; }
        public DateTime PostingDate { get; set; }

        public decimal? QuantityIn { get; set; }
        public decimal? QuantityOut { get; set; }

        public decimal BalanceAfter { get; set; }

        public decimal? UnitCost { get; set; }

        public string TransactionType { get; set; } = null!;
        public string? SourceType { get; set; }
        public long? ReferenceDocumentId { get; set; }

        public CostingMethodEnum CostingMethod { get; set; }  // FIFO / Average


        public string? Description { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}