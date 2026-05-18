using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs
{
    public class CompanyReturnSearchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }

        public string? Website { get; set; }
        public string? IndustrySector { get; set; }

        public string? BuildingNumber { get; set; }
        public string? Street { get; set; }
        public string? Zone { get; set; }

        public string TaxIdNumber { get; set; } = string.Empty;
        public string CommercialRegisterNumber { get; set; } = string.Empty;

        public long CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;

        public long CityId { get; set; }
        public string? CityName { get; set; }
        public string? CityCode { get; set; }

        public long BaseCurrencyId { get; set; }
        public string? BaseCurrencyName { get; set; }
        public string? BaseCurrencyCode { get; set; }

        public long OfficialCurrencyId { get; set; }
        public string? OfficialCurrencyName { get; set; }
        public string? OfficialCurrencyCode { get; set; }

        public CostingMethodEnum? CostingMethodEnum { get; set; }


        //new
        public long? ReportingCurrencyId { get; set; }
        public long? DefaultTaxTypeId { get; set; }
        public long? DefaultTaxType2Id { get; set; }

        //FK
        public long InventoryAccountId { get; set; }
        public long CogsAccountId { get; set; }
        public long AdjustmentAccountId { get; set; }
        public long RevenueAccountId { get; set; }
        public long PurchaseAccountId { get; set; }
        public long PurchaseReturnAccountId { get; set; }
        public long SalesReturnAccountId { get; set; }
        public long GoodsReceivedNotInvoicedAccountId { get; set; }
        public long WipAccountId { get; set; }

        //Bit
        public bool ActiveCostCenter { get; set; }
        public bool ActiveCostUnit { get; set; }
        public bool ActiveOperation { get; set; }
        public bool ActiveWBS { get; set; }
        public bool ActiveCostCode { get; set; }
        public bool ActiveActivity { get; set; }
        public bool ActiveBOQItem { get; set; }
        public bool ActiveSubcontractBOQ { get; set; }
        public bool ActiveProductionOrder { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
