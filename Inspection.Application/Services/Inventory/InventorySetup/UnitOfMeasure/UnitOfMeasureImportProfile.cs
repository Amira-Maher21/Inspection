using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasure;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inventory.InventorySetup.UnitOfMeasure
{
    internal class UnitOfMeasureImportProfile : IImportProfile<UnitOfMeasureCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public UnitOfMeasureImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Code",
                "Name",
                "Description",
                "IsBaseUnit",
            }.AsReadOnly();
        }

        // Map from Dictionary (for legacy or other usages)
        public Task<UnitOfMeasureCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new UnitOfMeasureCreateDto
            {
                Code = Normalize(row.GetValueOrDefault("Code")) ?? string.Empty,
                Name = Normalize(row.GetValueOrDefault("Name")) ?? string.Empty,
                Description = Normalize(row.GetValueOrDefault("Description")) ?? string.Empty,
                IsBaseUnit = ParseBool(row.GetValueOrDefault("IsBaseUnit"))
            };

            return Task.FromResult(dto);
        }



        public Task ValidateAsync(
            UnitOfMeasureCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("IsBaseUnit")))
                errors.Add("IsBaseUnit is required.");

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
