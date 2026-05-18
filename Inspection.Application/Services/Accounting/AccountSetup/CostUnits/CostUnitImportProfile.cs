using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostUnitDTOs;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Accounting.AccountSetup.CostUnits
{
    public class CostUnitImportProfile : IImportProfile<CostUnitCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public CostUnitImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",
                "Code",
                "Name",
                "IsMain",
                "ParentCostUnitId"
            }.AsReadOnly();
        }

        public Task<CostUnitCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new CostUnitCreateDto
            {
                CompanyId = ParseLong(row.GetValueOrDefault("CompanyId"), errors, "CompanyId"),
                Code = row.GetValueOrDefault("Code") ?? string.Empty,
                Name = row.GetValueOrDefault("Name") ?? string.Empty,
                IsMain = ParseBool(row.GetValueOrDefault("IsMain"), true),
                ParentCostUnitId = ParseNullableLong(row.GetValueOrDefault("ParentCostUnitId"), errors, "ParentCostUnitId")
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            CostUnitCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required and must be greater than zero.");

            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (dto.ParentCostUnitId.HasValue && dto.ParentCostUnitId <= 0)
                errors.Add("ParentCostUnitId must be greater than zero when provided.");

            return Task.CompletedTask;
        }

        // Helpers
        private static long ParseLong(
            string? value,
            List<string> errors,
            string columnName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errors.Add($"{columnName} is required.");
                return 0;
            }

            if (!long.TryParse(value, out var result))
            {
                errors.Add($"{columnName} must be a valid number.");
                return 0;
            }

            return result;
        }

        private static long? ParseNullableLong(
            string? value,
            List<string> errors,
            string columnName)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (!long.TryParse(value, out var result))
            {
                errors.Add($"{columnName} must be a valid number.");
                return null;
            }

            return result;
        }

        private static bool ParseBool(string? value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }
    }
}