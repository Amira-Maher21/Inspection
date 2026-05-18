using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierContacts;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers
{
    public class SuppliersCreateDTOs
    {
        public string Code { get; set; } = string.Empty;
        //// series related
        //public long? SeriesId { get; set; }
        //public int RunningNumber { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; }
        public string? NationId { get; set; }
        public string? TaxRegistration { get; set; }
        public string? CommercialRegistry { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public long? PaymentTermsId { get; set; }
        public decimal? CreditLimit { get; set; }
        public bool Dsiable { get; set; }
        public string? Notes { get; set; }


        public long CountryId { get; set; }
        public long CityId { get; set; }
        public long CurrencyId { get; set; }
        public long? TaxCategoryId { get; set; }
        public long? SupplierGroupId { get; set; }




        public ICollection<SupplierContactDTOs> SupplierContactDTOs { get; set; } = new List<SupplierContactDTOs>();



    }
}
