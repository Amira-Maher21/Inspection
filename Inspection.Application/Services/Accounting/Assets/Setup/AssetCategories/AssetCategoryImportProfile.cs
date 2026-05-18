using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCategory;

namespace Inspection.Application.Services.Accounting.Assets.Setup.AssetCategories
{
    public class AssetCategoryImportProfile : IImportProfile<AssetCategoryCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public AssetCategoryImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Code",
                "Name",
                "DefaultUsefulLifeMonths",
                "DefaultDepreciationMethod",
                //"Tenant_ID"
            }.AsReadOnly();
        }

        public Task<AssetCategoryCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new AssetCategoryCreateDto
            {
                CategoryCode = row.GetValueOrDefault("Code")?.Trim() ?? string.Empty,
                CategoryName = row.GetValueOrDefault("Name")?.Trim() ?? string.Empty,
                DefaultUsefulLifeMonths = int.TryParse(row.GetValueOrDefault("DefaultUsefulLifeMonths"), out var life)
                                          ? life
                                          : 0,
                DefaultDepreciationMethod = Enum.TryParse(row.GetValueOrDefault("DefaultDepreciationMethod"), out DefaultDepreciationMethod method)
                                              ? method
                                              : 0,
                //Tenant_ID = row.GetValueOrDefault("Tenant_ID")?.Trim() ?? string.Empty
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            AssetCategoryCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.CategoryCode))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.CategoryName))
                errors.Add("Name is required.");

            if (dto.CategoryCode.Length > 50)
                errors.Add("Code must not exceed 50 characters.");

            if (dto.CategoryName.Length > 250)
                errors.Add("Name must not exceed 250 characters.");

            if (dto.DefaultUsefulLifeMonths <= 0)
                errors.Add("DefaultUsefulLifeMonths must be greater than zero.");

            if (dto.DefaultDepreciationMethod == 0)
                errors.Add("DefaultDepreciationMethod is required.");

            return Task.CompletedTask;
        }
    }
}
