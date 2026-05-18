namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches
{
    public class BranchReturnSearchDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;



        // Company
        public long CompanyId { get; set; }
        public string CompanyCode { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        // Country
        public long? CountryId { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }

        // City
        public long? CityId { get; set; }
        public string? CityCode { get; set; }
        public string? CityName { get; set; }

        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
