namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices.PurchaseInvoiceAdjustments
{
    public class PurchaseInvoiceAdjustmentDto
    {
        public long Id { get; set; }
        public long PurchaseInvoiceId { get; set; }
        public long ChartOfAccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public long CostCenterId { get; set; }
        public long CostUnitId { get; set; }
        public long OperationId { get; set; }


        public long? WBSId { get; private set; }
        public long? CostCodeId { get; private set; }
        public bool? Activity { get; private set; }
        public long? BOQLineId { get; private set; }
        public long? SubcontractBOQId { get; private set; }
        public long? ProductionOrderId { get; private set; }



        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
