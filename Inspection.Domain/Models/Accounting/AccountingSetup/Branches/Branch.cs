using Inspection.Domain.Models.SystemConfigurations.Cities;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.AccountingSetup.Branches
{
    public class Branch : IRootEntity, ITenantEntity, IAuditable
    {
        private Branch() { }

        public long Id { get; private set; }

        public string Tenant_ID { get; set; } = string.Empty;

        // Company
        public long CompanyId { get; private set; }
        public Company Company { get; private set; } = null!;

        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;


        public long? CountryId { get; private set; }
        public Country? Country { get; private set; } = null!;
        public long? CityId { get; private set; }
        public City? City { get; private set; } = null!;

        public string Address { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        public Branch(
            long companyId,
            string tenantId,
            string name,
            string code,

            string? description = null,
            long? countryId = null,
            long? cityId = null,
            string? address = null,
            string? phone = null,
            string? email = null)
        {


            CompanyId = companyId;
            Tenant_ID = tenantId;
            Name = name;
            Code = code;
            Description = description ?? string.Empty;



            CountryId = countryId;
            CityId = cityId;

            Address = address ?? string.Empty;
            Phone = phone ?? string.Empty;
            Email = email ?? string.Empty;

            In_Date = DateTime.UtcNow;
        }

        private static void ValidateBranchType(bool isSales, bool isWarehouse)
        {
            if (isSales == isWarehouse)
                throw new InvalidOperationException(
                    "Branch must be either Sales or Warehouse (only one = true).");
        }


        public void UpdateInfo(
        string name,
        string code,
        string? description,
         long? countryId,
        long? cityId,
        string? address,
        string? phone,
         string? email)
        {
            Name = name;
            Code = code;
            Description = description ?? string.Empty;
            CountryId = countryId;
            CityId = cityId;
            Address = address ?? string.Empty;
            Phone = phone ?? string.Empty;
            Email = email ?? string.Empty;
        }

    }
}