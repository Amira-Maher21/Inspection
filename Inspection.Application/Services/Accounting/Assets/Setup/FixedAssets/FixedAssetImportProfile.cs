using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetStatuss;
using Inspection.Domain.Enums.FixedAsset;

namespace Inspection.Application.Services.Accounting.Assets.Setup.FixedAssets
{
    public class FixedAssetImportProfile : IImportProfile<FixedAssetCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public FixedAssetImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Name",
                "CompanyId",

                "AssetCategoryCode",
                "AssetGroupCode",
                "AssetLocationCode",
                "CurrencyCode",
                "SupplierCode",

                "EmployeeCode",
                "DepartmentCode",

                "CostCenterCode",
                "CostUnitCode",

                "OperationCode",
                "WBSCode",
                "CostCodeCode",
                "ActivityCode",

                "BOQLineCode",
                "SubcontractBOQCode",
                "ProductionOrderCode",

                "AssetStatusEnum",
                "AcquisitionDate",
                "CapitalizationDate",

                "AcquisitionCost",
                "ResidualValue",
                "UsefulLifeMonths",

                "DepreciationMethod",
                "EstimatedUnits",

                "SerialNumber",
                "BarcodeValue",
                "ModelNumber",
                "Brand",

                "WarrantyStartDate",
                "WarrantyEndDate",

                "InsurancePolicyNo",
                "InsuranceStartDate",
                "InsuranceEndDate",
                "InsuranceValue",

                "IsCapitalized",
                "IsFullyDepreciated",

                "AccumulatedDepreciation",
                "NetBookValue",

                "Notes"
            }.AsReadOnly();
        }

        public Task<FixedAssetCreateDto> MapAsync(Dictionary<string, string> row, List<string> errors)
        {
            var dto = new FixedAssetCreateDto();

            dto.Name = GetString(row, "Name");

            dto.CompanyId = GetLong(row, "CompanyId");

            dto.AcquisitionDate = GetDate(row, "AcquisitionDate", errors);
            dto.CapitalizationDate = GetNullableDate(row, "CapitalizationDate");

            dto.AcquisitionCost = GetDecimal(row, "AcquisitionCost");
            dto.ResidualValue = GetDecimal(row, "ResidualValue");
            dto.UsefulLifeMonths = GetInt(row, "UsefulLifeMonths");

            dto.EstimatedUnits = GetNullableDecimal(row, "EstimatedUnits");

            dto.SerialNumber = GetStringNullable(row, "SerialNumber");
            dto.BarcodeValue = GetStringNullable(row, "BarcodeValue");
            dto.ModelNumber = GetStringNullable(row, "ModelNumber");
            dto.Brand = GetStringNullable(row, "Brand");

            dto.WarrantyStartDate = GetNullableDate(row, "WarrantyStartDate");
            dto.WarrantyEndDate = GetNullableDate(row, "WarrantyEndDate");

            dto.InsurancePolicyNo = GetStringNullable(row, "InsurancePolicyNo");
            dto.InsuranceStartDate = GetNullableDate(row, "InsuranceStartDate");
            dto.InsuranceEndDate = GetNullableDate(row, "InsuranceEndDate");
            dto.InsuranceValue = GetNullableDecimal(row, "InsuranceValue");

            dto.IsCapitalized = GetBool(row, "IsCapitalized");
            dto.IsFullyDepreciated = GetBool(row, "IsFullyDepreciated");

            dto.AccumulatedDepreciation = GetDecimal(row, "AccumulatedDepreciation");
            dto.NetBookValue = GetDecimal(row, "NetBookValue");

            dto.Notes = GetStringNullable(row, "Notes");

            // Enums (SAFE)
            dto.DepreciationMethod =
                Enum.TryParse<DepreciationMethod>(GetString(row, "DepreciationMethod"), true, out var dep)
                ? dep
                : default;

            dto.AssetStatusEnum =
                Enum.TryParse<AssetStatusEnum>(GetString(row, "AssetStatusEnum"), true, out var st)
                ? st
                : default;

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(FixedAssetCreateDto dto, Dictionary<string, string> row, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required.");

            if (dto.AcquisitionDate == default)
                errors.Add("AcquisitionDate is required.");

            if (dto.AcquisitionCost <= 0)
                errors.Add("AcquisitionCost must be greater than zero.");

            if (dto.UsefulLifeMonths <= 0)
                errors.Add("UsefulLifeMonths must be greater than zero.");

            return Task.CompletedTask;
        }

        // ================= SAFE HELPERS =================

        private static string GetString(Dictionary<string, string> row, string key)
            => row.TryGetValue(key, out var v) ? v?.Trim() ?? "" : "";

        private static string? GetStringNullable(Dictionary<string, string> row, string key)
            => row.TryGetValue(key, out var v) ? v?.Trim() : null;

        private static long GetLong(Dictionary<string, string> row, string key)
            => long.TryParse(GetString(row, key), out var v) ? v : 0;

        private static int GetInt(Dictionary<string, string> row, string key)
            => int.TryParse(GetString(row, key), out var v) ? v : 0;

        private static decimal GetDecimal(Dictionary<string, string> row, string key)
            => decimal.TryParse(GetString(row, key), out var v) ? v : 0;

        private static decimal? GetNullableDecimal(Dictionary<string, string> row, string key)
            => decimal.TryParse(GetString(row, key), out var v) ? v : null;

        private static DateTime GetDate(Dictionary<string, string> row, string key, List<string> errors)
        {
            if (DateTime.TryParse(GetString(row, key), out var d))
                return d;

            errors.Add($"{key} is invalid date");
            return default;
        }

        private static DateTime? GetNullableDate(Dictionary<string, string> row, string key)
            => DateTime.TryParse(GetString(row, key), out var d) ? d : null;

        private static bool GetBool(Dictionary<string, string> row, string key)
        {
            var val = GetString(row, key);
            return val is "1" or "true" or "yes" or "y";
        }
    }
}