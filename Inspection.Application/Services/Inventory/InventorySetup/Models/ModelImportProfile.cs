using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inventory.InventorySetup.Models
{
    public class ModelImportProfile : IImportProfile<ModelTampleteDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public ModelImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Code",
                "Name",
                "Description",
                "BrandCode"
            }.AsReadOnly();
        }

        public Task<ModelTampleteDto?> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new ModelTampleteDto
            {
                Code = row.GetValueOrDefault("Code")?.Trim() ?? string.Empty,
                Name = row.GetValueOrDefault("Name")?.Trim() ?? string.Empty,
                Description = row.GetValueOrDefault("Description")?.Trim(),
                BrandCode = row.GetValueOrDefault("BrandCode")?.Trim() ?? string.Empty
            };

            return Task.FromResult<ModelTampleteDto?>(dto);
        }

        public Task ValidateAsync(
            ModelTampleteDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (string.IsNullOrWhiteSpace(dto.BrandCode))
                errors.Add("BrandCode is required.");

            if (dto.Code.Length > 50)
                errors.Add("Code must not exceed 50 characters.");

            if (dto.Name.Length > 150)
                errors.Add("Name must not exceed 150 characters.");

            if (!string.IsNullOrWhiteSpace(dto.Description) &&
                dto.Description.Length > 255)
                errors.Add("Description must not exceed 255 characters.");

            return Task.CompletedTask;
        }
    }
}
