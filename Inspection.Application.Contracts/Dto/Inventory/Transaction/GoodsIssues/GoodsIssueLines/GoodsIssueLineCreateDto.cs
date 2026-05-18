namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues.GoodsIssueLines
{
    public class GoodsIssueLineCreateDto
    {

        public long ItemId { get; set; }
        public long UnitOfMeasureId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Cost { get; set; }
        public long? WarehouseId { get; set; }
        public long? WarehouseLocationId { get; set; }
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
