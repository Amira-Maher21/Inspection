namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs
{
    public class CommitmentLineDto
    {
        public long Id { get; set; }

        public long CommitmentId { get; set; }
        public long OperaionId { get; set; }
        public long WBSId { get; set; }
        public long CostCodeId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }

        public decimal CommittedQty { get; set; }
        public decimal CommittedRate { get; set; }
        public decimal CommittedAmount { get; set; }
        public decimal InvoicedAmount { get; set; }
        public decimal RemainingAmount { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}