using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SystemConfigurations.Companies
{
    public class Company : IRootEntity, ITenantEntity, IAuditable
    {
        //[Key]
        public long Id { get; private set; }

        // Required Core Fields
        public string Tenant_ID { get; set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        // Required Contact Info
        public string Address { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string? Email { get; private set; }

        // Optional Info
        public string? Website { get; private set; }
        public long? CompanyLogoPhotoid { get; private set; }
        public string? IndustrySector { get; private set; }

        public string? BuildingNumber { get; private set; }
        public string? Street { get; private set; }
        public string? Zone { get; private set; }

        // Required Legal Info
        public string TaxIdNumber { get; private set; } = string.Empty;
        public string CommercialRegisterNumber { get; private set; } = string.Empty;


        // Foreign Keys (Required)
        public long BaseCurrencyId { get; private set; }
        public Currency BaseCurrency { get; private set; } = null!;
        public long CountryId { get; private set; } // nullable
        public Country Country { get; private set; } = null!;

        public long OfficialCurrencyId { get; private set; }
        public Currency OfficialCurrency { get; private set; } = null!;

        public long CityId { get; private set; }
        public City City { get; private set; } = null!;
        public long? ReportingCurrencyId { get; private set; }
        public Currency? ReportingCurrency { get; private set; }

        //New
        public CostingMethodEnum? CostingMethodEnum { get; private set; }
        public long? DefaultTaxTypeId { get; private set; }
        public long? DefaultTaxType2Id { get; private set; }

        public long? InventoryAccountId { get; private set; }
        public long? CogsAccountId { get; private set; }
        public long? AdjustmentAccountId { get; private set; }
        public long? RevenueAccountId { get; private set; }
        public long? PurchaseAccountId { get; private set; }
        public long? PurchaseReturnAccountId { get; private set; }
        public long? SalesReturnAccountId { get; private set; }
        public long? GoodsReceivedNotInvoicedAccountId { get; private set; }
        public long? WipAccountId { get; private set; }
        public ChartOfAccount? DefaultTaxType { get; private set; }
        public ChartOfAccount? DefaultTaxType2 { get; private set; }
        public ChartOfAccount? InventoryAccount { get; private set; }
        public ChartOfAccount? CogsAccount { get; private set; }
        public ChartOfAccount? AdjustmentAccount { get; private set; }
        public ChartOfAccount? RevenueAccount { get; private set; }
        public ChartOfAccount? PurchaseAccount { get; private set; }
        public ChartOfAccount? PurchaseReturnAccount { get; private set; }
        public ChartOfAccount? SalesReturnAccount { get; private set; }
        public ChartOfAccount? GoodsReceivedNotInvoicedAccount { get; private set; }
        public ChartOfAccount? WipAccount { get; private set; }

        //Bit
        public bool ActiveCostCenter { get; private set; }
        public bool ActiveCostUnit { get; private set; }
        public bool ActiveOperation { get; private set; }
        public bool ActiveWBS { get; private set; }
        public bool ActiveCostCode { get; private set; }
        public bool ActiveActivity { get; private set; }
        public bool ActiveBOQItem { get; private set; }
        public bool ActiveSubcontractBOQ { get; private set; }
        public bool ActiveProductionOrder { get; private set; }

        // Audit Required
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }

        // Audit Optional
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}