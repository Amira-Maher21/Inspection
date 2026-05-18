using Inspection.Domain.Enums.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers
{
    public class SupplierReturnSearchDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public SupplierTypeEnum SupplierTypeEnum { get; set; } = SupplierTypeEnum.Company;

        public string? NationId { get; set; }
        public string? TaxRegistration { get; set; }
        public string? CommercialRegistry { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }

        //PaymentTerm
        public long? PaymentTermsId { get; set; }
        public string PaymentTermCode { get; set; }
        public string PaymentTermName { get; set; }


        public decimal? CreditLimit { get; set; }
        public bool Dsiable { get; set; }
        public string? Notes { get; set; }


        //FK
        public long CountryId { get; set; }
        public string CountryCode { get; set; } = null!;
        public string CountryName { get; set; } = null!;


        public long CityId { get; set; }
        public string CityCode { get; set; } = null!;
        public string CityName { get; set; } = null!;


        public long CurrencyId { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;



        public long? TaxCategoryId { get; set; }
        public string TaxCategoryName { get; set; } = null!;
        public string TaxCategoryCode { get; set; } = null!;



        public long SupplierGroupId { get; set; }
        public string SupplierGroupCode { get; set; }
        public string SupplierGroupNames { get; set; }

        public ICollection<SupplierContact> SupplierContacts { get; set; } = new List<SupplierContact>();



        public string Tenant_ID { get; set; } = string.Empty;


        // series related
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
    }
}
