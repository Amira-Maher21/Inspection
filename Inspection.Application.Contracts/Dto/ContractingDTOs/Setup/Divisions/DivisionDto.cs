namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions
{
    public class DivisionDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public string DivisionCode { get; set; } = string.Empty;
        public string DivisionName { get; set; } = string.Empty;

        public long? ParentDivisionId { get; set; }

        public bool IsLeaf { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
