using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inventory.InventorySetup.Sizes
{
    public class SizeImportProfile : IImportProfile<SizeCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public SizeImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Code",
                "Name",
                "Description"
            }.AsReadOnly();
        }

        public Task<SizeCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new SizeCreateDto
            {
                Code = row.GetValueOrDefault("Code")?.Trim() ?? string.Empty,
                Name = row.GetValueOrDefault("Name")?.Trim() ?? string.Empty,
                Description = row.GetValueOrDefault("Description")?.Trim() ?? string.Empty

            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            SizeCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");
            if (dto.Description?.Length > 250)
                errors.Add("Description must not exceed 250 characters.");

            return Task.CompletedTask;
        }
    }
}
