namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns.SalesReturnAdjustments
{
    public class SalesReturnAdjustmentDto
    {
        public long Id { get; set; }
        public long SalesReturnId { get; set; }
        public long ChartOfAccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public long? CostCenterId { get; set; }
        public long? CostUnitId { get; set; }
        public long? OperationId { get; set; }
        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
