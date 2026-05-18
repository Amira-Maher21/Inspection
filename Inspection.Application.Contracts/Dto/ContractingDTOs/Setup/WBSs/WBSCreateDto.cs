namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs
{
    public class WBSCreateDto
    {

        // FK
        public long OperationId { get; set; }

        public long? ParentWBSId { get; set; }


        // Required Fields
        public string WBSCode { get; set; } = string.Empty;
        public string WBSName { get; set; } = string.Empty;

        public int LevelNo { get; set; }

        public bool IsLeaf { get; set; } = false;

        // Multi-tenant

        public long CompanyId { get; set; }


    }
}
