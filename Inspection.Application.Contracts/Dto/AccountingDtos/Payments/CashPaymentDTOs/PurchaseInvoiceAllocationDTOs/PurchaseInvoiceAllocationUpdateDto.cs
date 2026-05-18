namespace Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.PurchaseInvoiceAllocationDTOs
{
    public class PurchaseInvoiceAllocationUpdateDto
    {
        public long Id { get; set; }
        public long PurchaseInvoiceId { get; set; }
        public long? PurchaseInvoiceLineId { get; set; }
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
    }
}