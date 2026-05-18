using Inspection.Domain.Enums.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.System.Taxestegories;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers
{
    [Table("Supplier")]
    public class Supplier : IRootEntity, ITenantEntity, IAuditable
    {

        public long Id { get; private set; }
        // series related
        public Series Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public SupplierTypeEnum SupplierTypeEnum { get; private set; } = SupplierTypeEnum.Company;

        public string? NationId { get; private set; }
        public string? TaxRegistration { get; private set; }
        public string? CommercialRegistry { get; private set; }
        public string Address { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string? Mobile { get; private set; }
        public string? Email { get; private set; }
        public string? Website { get; private set; }
        public long? PaymentTermsId { get; private set; }
        public PaymentTerm? PaymentTerm { get; private set; }
        public decimal? CreditLimit { get; private set; }
        public bool Dsiable { get; set; }
        public string? Notes { get; private set; }


        //FK
        public long CountryId { get; private set; }
        public Country Country { get; private set; } = null!;
        public long CityId { get; private set; }
        public City City { get; private set; } = null!;
        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;
        public long? TaxCategoryId { get; private set; }
        public TaxCategory TaxCategory { get; private set; } = null!;
        public long SupplierGroupId { get; set; }
        public SupplierGroup SupplierGroup { get; set; }

        public ICollection<SupplierContact> SupplierContacts { get; set; } = new List<SupplierContact>();



        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }



        //public void Disable()
        //{
        //    Dsiable = true;

        //    if (SupplierContacts != null && SupplierContacts.Any())
        //    {
        //        foreach (var contact in SupplierContacts)
        //        {
        //            contact.SetAsNotPrimary();
        //        }
        //    }
        //}



    }
}
