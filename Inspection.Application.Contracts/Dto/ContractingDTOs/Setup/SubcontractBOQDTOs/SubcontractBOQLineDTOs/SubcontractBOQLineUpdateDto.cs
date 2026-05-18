namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs.SubcontractBOQLineDTOs
{
    public class SubcontractBOQLineUpdateDto
    {
        public long Id { get; set; }
        public string BOQItemCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UnitId { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }
    }
}