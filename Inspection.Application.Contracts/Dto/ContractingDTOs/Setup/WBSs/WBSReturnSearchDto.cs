namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs
{
    public class WBSReturnSearchDto
    {
        public long Id { get; set; }

        // FK
        public long OperationId { get; set; }
        public string OperationName { get; set; }
        public string OperationCode { get; set; }

        public long? ParentWBSId { get; set; }
        public string? ParentWBSName { get; set; }
        public string? ParentWBSCode { get; set; }


        // Required Fields
        public string WBSCode { get; set; } = string.Empty;
        public string WBSName { get; set; } = string.Empty;

        public int LevelNo { get; set; }

        public bool IsLeaf { get; set; }


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
