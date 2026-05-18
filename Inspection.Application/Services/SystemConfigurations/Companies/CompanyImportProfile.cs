//using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
//using Inspection.Application.Shared.ImportFiles;

//namespace Inspection.Application.Services.SystemConfigurations.Companies
//{

//    public class CompanyImportProfile : IImportProfile<CompanyCreateDto>
//    {
//        public IReadOnlyList<string> ColumnOrder { get; }

//        public CompanyImportProfile()
//        {
//            ColumnOrder = new List<string>
//            {
//                "Code",
//                "Name",
//                "Address",
//                "PhoneNumber",
//                "Email",
//                "Website",
//                "IndustrySector",
//                "SubEntity",
//                "BuildingNumber",
//                "Street",
//                "Zone",
//                "LegalRegistrationNumber",
//                "TaxIdNumber",
//                "CommercialRegisterNumber",
//                "IsHolding",
//                "IsSubsidiary",
//                "IsActive",
//                "CountryCode",
//                "CityCode",
//                "CurrencyCode"
//            }.AsReadOnly();
//        }

//        public Task<CompanyCreateDto> MapAsync(
//            Dictionary<string, string> row,
//            List<string> errors)
//        {
//            var dto = new CompanyCreateDto
//            {
//                Code = row.GetValueOrDefault("Code") ?? string.Empty,
//                Name = row.GetValueOrDefault("Name") ?? string.Empty,
//                Address = row.GetValueOrDefault("Address") ?? string.Empty,
//                PhoneNumber = row.GetValueOrDefault("PhoneNumber") ?? string.Empty,
//                Email = row.GetValueOrDefault("Email") ?? string.Empty,
//                Website = Normalize(row.GetValueOrDefault("Website")),
//                IndustrySector = Normalize(row.GetValueOrDefault("IndustrySector")),
//                BuildingNumber = Normalize(row.GetValueOrDefault("BuildingNumber")),
//                Street = Normalize(row.GetValueOrDefault("Street")),
//                Zone = Normalize(row.GetValueOrDefault("Zone")),
//                TaxIdNumber = row.GetValueOrDefault("TaxIdNumber") ?? string.Empty,
//                CommercialRegisterNumber = row.GetValueOrDefault("CommercialRegisterNumber") ?? string.Empty,

//            };

//            return Task.FromResult(dto);
//        }

//        public Task ValidateAsync(
//            CompanyCreateDto dto,
//            Dictionary<string, string> row,
//            List<string> errors)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Code))
//                errors.Add("Code is required.");

//            if (string.IsNullOrWhiteSpace(dto.Name))
//                errors.Add("Name is required.");



//            if (string.IsNullOrWhiteSpace(dto.TaxIdNumber))
//                errors.Add("TaxIdNumber is required.");

//            if (string.IsNullOrWhiteSpace(dto.CommercialRegisterNumber))
//                errors.Add("CommercialRegisterNumber is required.");

//            return Task.CompletedTask;
//        }

//        private static string? Normalize(string? value)
//            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

//        private static bool ParseBool(string? value, bool defaultValue = false)
//        {
//            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
//            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
//        }
//    }
//}



using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums;

namespace Inspection.Application.Services.SystemConfigurations.Companies
{
    public class CompanyImportProfile : IImportProfile<CompanyCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public CompanyImportProfile()
        {
            ColumnOrder = new List<string>
            {

                "Code",
                "Name",
                "Address",
                "PhoneNumber",
                "Email",
                "Website",
                "IndustrySector",
                "BuildingNumber",
                "Street",
                "Zone",
                "TaxIdNumber",
                "CommercialRegisterNumber",

                // Location
                "CountryCode",
                "CityCode",

                // Currencies
                "BaseCurrencyCode",
                "OfficialCurrencyCode",
                "ReportingCurrencyCode",

                // Taxes
                "DefaultTaxTypeCode",
                "DefaultTaxType2Code",

                // Accounts
                "InventoryAccountCode",
                "CogsAccountCode",
                "AdjustmentAccountCode",
                "RevenueAccountCode",
                "PurchaseAccountCode",
                "PurchaseReturnAccountCode",
                "SalesReturnAccountCode",
                "GRNIAccountCode",
                "WipAccountCode",

                // Costing
                "CostingMethod",

                // Flags
                "ActiveCostCenter",
                "ActiveCostUnit",
                "ActiveOperation",
                "ActiveWBS",
                "ActiveCostCode",
                "ActiveActivity",
                "ActiveBOQItem",
                "ActiveSubcontractBOQ",
                "ActiveProductionOrder"
            }.AsReadOnly();
        }

        public Task<CompanyCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new CompanyCreateDto
            {

                Code = row.GetValueOrDefault("Code") ?? string.Empty,
                Name = row.GetValueOrDefault("Name") ?? string.Empty,
                Address = row.GetValueOrDefault("Address") ?? string.Empty,
                PhoneNumber = row.GetValueOrDefault("PhoneNumber") ?? string.Empty,
                Email = row.GetValueOrDefault("Email") ?? string.Empty,

                Website = Normalize(row.GetValueOrDefault("Website")),
                IndustrySector = Normalize(row.GetValueOrDefault("IndustrySector")),
                BuildingNumber = Normalize(row.GetValueOrDefault("BuildingNumber")),
                Street = Normalize(row.GetValueOrDefault("Street")),
                Zone = Normalize(row.GetValueOrDefault("Zone")),

                TaxIdNumber = row.GetValueOrDefault("TaxIdNumber") ?? string.Empty,
                CommercialRegisterNumber = row.GetValueOrDefault("CommercialRegisterNumber") ?? string.Empty,

                // Flags
                ActiveCostCenter = ParseBool(row.GetValueOrDefault("ActiveCostCenter")),
                ActiveCostUnit = ParseBool(row.GetValueOrDefault("ActiveCostUnit")),
                ActiveOperation = ParseBool(row.GetValueOrDefault("ActiveOperation")),
                ActiveWBS = ParseBool(row.GetValueOrDefault("ActiveWBS")),
                ActiveCostCode = ParseBool(row.GetValueOrDefault("ActiveCostCode")),
                ActiveActivity = ParseBool(row.GetValueOrDefault("ActiveActivity")),
                ActiveBOQItem = ParseBool(row.GetValueOrDefault("ActiveBOQItem")),
                ActiveSubcontractBOQ = ParseBool(row.GetValueOrDefault("ActiveSubcontractBOQ")),
                ActiveProductionOrder = ParseBool(row.GetValueOrDefault("ActiveProductionOrder"))
            };

            // 🔴 Costing Method Enum
            var costing = row.GetValueOrDefault("CostingMethod");
            if (!string.IsNullOrWhiteSpace(costing) &&
                Enum.TryParse<CostingMethodEnum>(costing, true, out var costingEnum))
            {
                dto.CostingMethodEnum = costingEnum;
            }
            else if (!string.IsNullOrWhiteSpace(costing))
            {
                errors.Add($"Invalid CostingMethod '{costing}'");
            }


            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            CompanyCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (string.IsNullOrWhiteSpace(dto.Address))
                errors.Add("Address is required.");

            if (string.IsNullOrWhiteSpace(dto.PhoneNumber))
                errors.Add("PhoneNumber is required.");

            if (string.IsNullOrWhiteSpace(dto.Email))
                errors.Add("Email is required.");

            if (string.IsNullOrWhiteSpace(dto.TaxIdNumber))
                errors.Add("TaxIdNumber is required.");

            if (string.IsNullOrWhiteSpace(dto.CommercialRegisterNumber))
                errors.Add("CommercialRegisterNumber is required.");

            // Optional but recommended
            //if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("CountryCode")))
            //    errors.Add("CountryCode is required.");

            //if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("CityCode")))
            //    errors.Add("CityCode is required.");

            //if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("BaseCurrencyCode")))
            //    errors.Add("BaseCurrencyCode is required.");

            //if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("OfficialCurrencyCode")))
            //    errors.Add("OfficialCurrencyCode is required.");

            return Task.CompletedTask;
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

        private static bool ParseBool(string? value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }
    }
}