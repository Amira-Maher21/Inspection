using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Colors;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inventory.InventorySetup.Colors
{

    public class ColorImportProfile : IImportProfile<ColorCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public ColorImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Code",
                "Name",
                "HexCode"
            }.AsReadOnly();
        }

        public Task<ColorCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new ColorCreateDto
            {
                Code = row.GetValueOrDefault("Code")?.Trim() ?? string.Empty,
                Name = row.GetValueOrDefault("Name")?.Trim() ?? string.Empty,
                HexCode = row.GetValueOrDefault("HexCode")?.Trim() ?? string.Empty

            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            ColorCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");
            if (dto.HexCode?.Length > 250)
                errors.Add("HexCode must not exceed 250 characters.");

            return Task.CompletedTask;
        }
    }

}
