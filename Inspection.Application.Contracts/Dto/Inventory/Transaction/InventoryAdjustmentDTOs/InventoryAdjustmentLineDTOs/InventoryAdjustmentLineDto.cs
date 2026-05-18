namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs.InventoryAdjustmentLineDTOs
{
    public class InventoryAdjustmentLineDto
    {
        public long Id { get; set; }
        public long InventoryAdjustmentId { get; set; }

        public decimal SystemQty { get; set; }
        public decimal CountedQty { get; set; }
        public decimal DifferenceQty { get; set; } // CountedQty - SystemQty
        public decimal? Cost { get; set; }
        public decimal? Adjustment { get; set; }
        public string? Notes { get; set; }

        public long ItemId { get; set; }
        public long GoodsTransferInId { get; set; }
        public long UnitOfMeasureId { get; set; }
        public long? WarehouseLocationId { get; set; }
        public long? CostCenterId { get; set; }
        public long? CostUnitId { get; set; }
        public long? OperationId { get; set; }

        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}