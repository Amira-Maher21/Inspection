namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptAdjustmentDTOs
{
    public class CashReceiptAdjustmentDto
    {
        public long Id { get; set; }
        public long CashReceiptId { get; set; }
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

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}