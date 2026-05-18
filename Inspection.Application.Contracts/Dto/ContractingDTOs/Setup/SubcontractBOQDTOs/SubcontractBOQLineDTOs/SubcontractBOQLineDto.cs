namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs.SubcontractBOQLineDTOs
{
    public class SubcontractBOQLineDto
    {
        public long Id { get; set; }
        public long SubcontractBOQId { get; set; }

        public string BOQItemCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UnitId { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}