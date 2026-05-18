namespace Inspection.Application.Contracts.Dto.Manufacturing.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs
{
    public class ProductionOrderLineUpdateDto
    {
        public long Id { get; set; }

        public long ProductionOrderId { get; set; }

        public long ItemId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Amount { get; set; }

        public long WBSId { get; set; }
        public long CostCodeId { get; set; }
    }
}