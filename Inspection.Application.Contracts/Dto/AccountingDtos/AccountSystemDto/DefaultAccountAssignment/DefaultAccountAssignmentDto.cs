namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountAssignment
{
    public class DefaultAccountAssignmentDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long DefaultAccountGroupID { get; set; }
        public long DefaultAccountTypeID { get; set; }

        public long AccountID { get; set; }
        public long CurrencyID { get; set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
