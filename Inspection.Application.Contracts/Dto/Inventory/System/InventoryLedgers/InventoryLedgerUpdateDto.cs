using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.PostingEngine;

namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers
{
    public class InventoryLedgerUpdateDto
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public long WarehouseId { get; set; }
        public long? WarehouseLocationId { get; set; }
        public long ItemId { get; set; }


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

        public CostingMethodEnum CostingMethod { get; set; } // FIFO / Average

        public long PostingDocumentTypeId { get; set; }

        public string? Description { get; set; }



    }
}