using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Accounting.AccountSetup.CostCenters
{
    public class CostCenterImportProfile : IImportProfile<CostCenterCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public CostCenterImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Code",
                "Name",
                "IsMain",
                "ParentCostCenterCode",
                "CompanyCode",
                "DepartmentCode"
            }.AsReadOnly();
        }

        public Task<CostCenterCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new CostCenterCreateDto
            {
                Code = row.GetValueOrDefault("Code")?.Trim() ?? string.Empty,
                Name = row.GetValueOrDefault("Name")?.Trim() ?? string.Empty,
                IsMain = ParseBool(row.GetValueOrDefault("IsMain")),
                //ParentCostCenterId = long.TryParse(row.GetValueOrDefault("ParentCostCenterId"), out var parentId)
                //                     ? parentId
                //                     : null,
                //DepartmentId = long.TryParse(row.GetValueOrDefault("DepartmentId"), out var deptId)
                //               ? deptId
                //               : null
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            CostCenterCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (dto.Code.Length > 50)
                errors.Add("Code must not exceed 50 characters.");

            if (dto.Name.Length > 250)
                errors.Add("Name must not exceed 250 characters.");

            return Task.CompletedTask;
        }

        private static bool ParseBool(string? value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }
    }
}
