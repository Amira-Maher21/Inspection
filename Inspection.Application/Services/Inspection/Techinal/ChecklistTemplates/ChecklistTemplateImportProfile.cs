using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inspection.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateImportProfile
        : IImportProfile<ChecklistTemplateCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public ChecklistTemplateImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "Name",
                "EquipmentTypeCode",
                "StandardCode",
                "CompanyCode",
                "SeriesCode",
                "Version",
                "Disabled"
            }.AsReadOnly();
        }

        public Task<ChecklistTemplateCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new ChecklistTemplateCreateDto
            {
                Name = row.GetValueOrDefault("Name")?.Trim() ?? string.Empty,
                Disabled = ParseBool(row.GetValueOrDefault("Disabled"))
            };

            if (int.TryParse(row.GetValueOrDefault("Version"), out var v))
                dto.Version = v;

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            ChecklistTemplateCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required.");

            if (dto.Version <= 0)
                errors.Add("Version must be greater than zero.");

            return Task.CompletedTask;
        }


        private static bool ParseBool(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }
    }
}
