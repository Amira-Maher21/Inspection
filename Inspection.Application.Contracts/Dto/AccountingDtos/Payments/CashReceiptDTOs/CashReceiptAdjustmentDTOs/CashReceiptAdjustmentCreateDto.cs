namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptAdjustmentDTOs
{
    public class CashReceiptAdjustmentCreateDto
    {
        public long AccountId { get; set; }
        public decimal Amount { get; set; }
        public long? CostCenterId { get; set; }
        public long? CostUnitId { get; set; }
        public long? OperationId { get; set; }
        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }
        public string? Description { get; set; }
    }
}