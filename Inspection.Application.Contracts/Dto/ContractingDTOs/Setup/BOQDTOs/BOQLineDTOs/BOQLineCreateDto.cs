namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs
{
    public class BOQLineCreateDto
    {
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