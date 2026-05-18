namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs.InventoryOpeningBalanceLineDTOs
{
    public class InventoryOpeningBalanceLineCreateDto : IInventoryLineHasSerialAndQty
    {
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? SerialNumber { get; set; }
        public string? Notes { get; set; }

        public long ItemId { get; set; }
        public long? WarehouseLocationId { get; set; }
        public long? BatchId { get; set; }
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