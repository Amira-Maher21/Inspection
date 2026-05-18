namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes
{
    public class CostCodeUpdateDto
    {
        public long Id { get; set; }

        // Required Fields
        public string CostCodeValue { get; set; } = string.Empty; // CostCode
        public string CostCodeName { get; set; } = string.Empty;

        // FK
        public long DivisionId { get; set; }

        // Tree Structure
        public long? ParentCostCodeId { get; set; }


        // Leaf
        public bool IsLeaf { get; set; }


        public long CompanyId { get; set; }


    }
}
