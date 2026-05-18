namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs.GoodsTransferOutLineDTOs
{
    public class GoodsTransferOutLineCreateDto
    {
        public decimal Quantity { get; set; }
        public decimal? Cost { get; set; }
        public bool FreeItem { get; set; }
        public string? Notes { get; set; }

        public long ItemId { get; set; }
        public long UnitOfMeasureId { get; set; }
        public long? WareHouseId { get; set; }
        public long? CostCenterId { get; set; }
        public long? CostUnitId { get; set; }
        public long? OperationId { get; set; }
        public long? WarehouseLocationId { get; set; }

        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }
    }
}