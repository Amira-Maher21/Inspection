using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.InventorySetup
{
    public class Warehouse : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public long? BranchId { get; private set; }
        public Branch Branch { get; private set; }
        public long? CountryId { get; private set; }
        public Country Country { get; private set; }
        public long? CityId { get; private set; }
        public City? City { get; private set; }

        public string Address { get; private set; } = string.Empty;
        public long? ResponsibleEmployeeId { get; private set; }
        public Employee? Employee { get; private set; }
        public long? InventoryAccountId { get; private set; }
        public ChartOfAccount? ChartOfAccount { get; private set; }


        public string ContactPhone { get; private set; } = string.Empty;
        public string ContactEmail { get; private set; } = string.Empty;


        //company id
        public long CompanyId { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}
