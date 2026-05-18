namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs
{
    public class CreateLedgerLineDto
    {
        public long LedgerId { get; set; }

        public long? ChartOfAccountId { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }

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
