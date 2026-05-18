using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Domain.Enums.Accounting;

public class CustomerReturnSearchDto
{
    public long Id { get; set; }
    // series related
    public long? SeriesId { get; set; }
    public int RunningNumber { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public CustomerTypeEnum CustomerType { get; set; }

    public string? NationalId { get; set; }
    public string? TaxRegistrationNo { get; set; }
    public string? CommercialRegistryNo { get; set; }

    public long CountryId { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;

    public long CityId { get; set; }
    public string CityCode { get; set; } = string.Empty;
    public string CityName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }

    public long CustomerGroupId { get; set; }
    public string CustomerGroupCode { get; set; } = string.Empty;
    public string CustomerGroupName { get; set; } = string.Empty;

    public long? CurrencyId { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public string CurrencyName { get; set; } = string.Empty;

    public long? PaymentTermId { get; set; }
    public string PaymentTermCode { get; set; } = string.Empty;
    public string PaymentTermName { get; set; } = string.Empty;

    public long? TaxCategoryId { get; set; }
    public string TaxCategoryCode { get; set; } = string.Empty;
    public string TaxCategoryName { get; set; } = string.Empty;

    public decimal? CreditLimit { get; set; }
    public bool Disable { get; set; }
    public string? Notes { get; set; }

    public List<CustomerContactDto> CustomerContact { get; set; } = new();
    public List<CustomerLocationDto> CustomerLocation { get; set; } = new();
    public List<CustomerProjectDto> CustomerProject { get; set; } = new();
}
