namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches
{
    public class BranchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;

        public long CompanyId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;


        public long? CountryId { get; set; }
        public long? CityId { get; set; }

        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}
