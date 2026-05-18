namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches
{
    public class BranchUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;



        public long CompanyId { get; set; }

        public long? CountryId { get; set; }
        public long? CityId { get; set; }

        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
