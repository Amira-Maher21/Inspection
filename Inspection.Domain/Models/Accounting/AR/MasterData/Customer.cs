using Inspection.Domain.Enums.Accounting;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.System.Taxestegories;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.AR.MasterData
{
    public class Customer : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; } // PK

        public string Tenant_ID { get; set; }
        // series related
        public Series Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string Code { get; set; } = null!;
        public string Name { get; private set; } = null!;
        public CustomerTypeEnum CustomerType { get; private set; } = CustomerTypeEnum.Company;

        public string? NationalId { get; private set; } // Conditional
        public string? TaxRegistrationNo { get; private set; } // Conditional
        public string? CommercialRegistryNo { get; private set; } // Conditional

        public long CountryId { get; private set; }
        public Country Country { get; private set; } = null!;

        public long CityId { get; private set; }
        public City City { get; private set; } = null!;

        public string Address { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public string? Mobile { get; private set; }
        public string? Email { get; private set; }
        public string? Website { get; private set; }

        public long CustomerGroupId { get; private set; }
        public CustomerGroup CustomerGroup { get; private set; }
        public long? CurrencyId { get; private set; }
        public Currency? Currency { get; private set; }

        public long? PaymentTermId { get; private set; }
        public PaymentTerm? paymentTerm { get; private set; }

        public long? TaxCategoryId { get; private set; }
        public TaxCategory? TaxCategory { get; private set; }

        public decimal? CreditLimit { get; private set; }

        public bool Disable { get; set; } // Active / Inactive
        public string? Notes { get; private set; }


        public List<CustomerContact> CustomerContact { get; set; } = new List<CustomerContact>();
        public List<CustomerLocation> CustomerLocation { get; set; } = new List<CustomerLocation>();
        public List<CustomerProject> CustomerProject { get; set; } = new List<CustomerProject>();

        // Auditing
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


        private Customer() { }







    }
}
