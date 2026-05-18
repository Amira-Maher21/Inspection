using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Brands;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inventory.InventorySetup.Brands
{
    public class BrandImportProfile : IImportProfile<BrandCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public BrandImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Code",
                "Name",
                "Description"
            }.AsReadOnly();
        }

        public Task<BrandCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new BrandCreateDto
            {
                Code = row.GetValueOrDefault("Code")?.Trim() ?? string.Empty,
                Name = row.GetValueOrDefault("Name")?.Trim() ?? string.Empty,
                Description = row.GetValueOrDefault("Description")?.Trim() ?? string.Empty
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            BrandCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (dto.Code.Length > 50)
                errors.Add("Code must not exceed 50 characters.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (dto.Name.Length > 150)
                errors.Add("Name must not exceed 150 characters.");

            if (!string.IsNullOrWhiteSpace(dto.Description) &&
                dto.Description.Length > 255)
                errors.Add("Description must not exceed 255 characters.");

            return Task.CompletedTask;
        }
    }
}
