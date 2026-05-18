using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs
{
    public class CompanyUpdateDto
    {
        public long Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }

        public string? Website { get; set; }
        public long? CompanyLogoPhotoid { get; set; }
        public string? IndustrySector { get; set; }

        public string? BuildingNumber { get; set; }
        public string? Street { get; set; }
        public string? Zone { get; set; }

        public string TaxIdNumber { get; set; } = string.Empty;
        public string CommercialRegisterNumber { get; set; } = string.Empty;

        public long BaseCurrencyId { get; set; }
        public long CountryId { get; set; }
        public long OfficialCurrencyId { get; set; }

        public long CityId { get; set; }
        public long? ReportingCurrencyId { get; set; }
        public long? DefaultTaxTypeId { get; set; }
        public long? DefaultTaxType2Id { get; set; }

        public long InventoryAccountId { get; set; }

        public long CogsAccountId { get; set; }

        public long AdjustmentAccountId { get; set; }
        public long RevenueAccountId { get; set; }
        public long PurchaseAccountId { get; set; }
        public long PurchaseReturnAccountId { get; set; }
        public long SalesReturnAccountId { get; set; }
        public long GoodsReceivedNotInvoicedAccountId { get; set; }
        public long WipAccountId { get; set; }

        public CostingMethodEnum? CostingMethodEnum { get; private set; }


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
    }

}