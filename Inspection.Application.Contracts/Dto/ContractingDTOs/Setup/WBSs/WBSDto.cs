namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs
{
    public class WBSDto
    {
        public long Id { get; set; }

        // FK
        public long OperationId { get; set; }

        public long? ParentWBSId { get; set; }


        // Required Fields
        public string WBSCode { get; set; } = string.Empty;
        public string WBSName { get; set; } = string.Empty;

        public int LevelNo { get; set; }

        public bool IsLeaf { get; set; } = false;

        // Multi-tenant
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }

        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }

}
