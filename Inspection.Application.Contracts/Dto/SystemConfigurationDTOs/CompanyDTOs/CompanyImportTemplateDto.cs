namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs
{
    public class CompanyImportTemplateDto
    {
        //[ExcelIgnore]

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }

        public string? Website { get; set; }
        public string? IndustrySector { get; set; }

        public string? SubEntity { get; set; }
        public string? BuildingNumber { get; set; }
        public string? Street { get; set; }
        public string? Zone { get; set; }

        public string LegalRegistrationNumber { get; set; } = string.Empty;
        public string TaxIdNumber { get; set; } = string.Empty;
        public string CommercialRegisterNumber { get; set; } = string.Empty;

        public bool IsHolding { get; set; }
        public bool IsSubsidiary { get; set; }
        public bool IsActive { get; set; }

        // FK as Codes
        public string CountryCode { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
    }
}