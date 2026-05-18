using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Domain.Enums.Accounting;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData
{
    public class CustomerUpdateDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;
        public CustomerTypeEnum? CustomerType { get; set; }
        public string Code { get; set; } = null!;

        public string? NationalId { get; set; }
        public string? TaxRegistrationNo { get; set; }
        public string? CommercialRegistryNo { get; set; }

        public long CountryId { get; set; }

        public long CityId { get; set; }

        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }

        public long CustomerGroupId { get; set; }

        public long? CurrencyId { get; set; }

        public long? PaymentTermId { get; set; }

        public long? TaxCategoryId { get; set; }

        public decimal? CreditLimit { get; set; }

        public bool Disable { get; set; }
        public string? Notes { get; set; }
        // series related
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public List<CustomerContactDto> CustomerContact { get; set; } = new List<CustomerContactDto>();
        public List<CustomerLocationDto> CustomerLocation { get; set; } = new List<CustomerLocationDto>();
        public List<CustomerProjectDto> CustomerProject { get; set; } = new List<CustomerProjectDto>();
    }
}
