namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs
{
    public class LedgerLineDto
    {
        public long Id { get; set; }

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

        // Auditing
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
