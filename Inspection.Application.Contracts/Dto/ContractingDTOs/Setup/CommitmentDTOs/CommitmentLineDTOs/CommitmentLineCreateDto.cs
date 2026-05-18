namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs
{
    public class CommitmentLineCreateDto
    {
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
    }
}