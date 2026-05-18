using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Checklists;

namespace Inspection.Application.Services.Inspection.Techinal.Checklists
{
    public class ChecklistImportProfile
        : IImportProfile<ChecklistCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public ChecklistImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "EquipmentCode",
                "InspectorCode",
                "ChecklistTemplateCode",
                "InspectionTypeCode",
                "InspectionDate",
                "StandardCode",
                "Location",
                "EquipmentStatus",
                "Remarks"
            }.AsReadOnly();
        }

        public Task<ChecklistCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new ChecklistCreateDto
            {
                Location = row.GetValueOrDefault("Location")?.Trim() ?? string.Empty,
                Remarks = row.GetValueOrDefault("Remarks")?.Trim() ?? string.Empty,
                DocStatus = ChecklistDocStatus.Draft
            };

            // Inspection Date
            if (DateTime.TryParse(row.GetValueOrDefault("InspectionDate"), out var inspectionDate))
                dto.InspectionDate = inspectionDate;
            else
                errors.Add("Invalid InspectionDate format.");

            // Equipment Status
            if (Enum.TryParse<EquipmentStatus>(
                    row.GetValueOrDefault("EquipmentStatus"),
                    true,
                    out var status))
            {
                dto.Status = status;
            }
            else
            {
                errors.Add("Invalid EquipmentStatus value.");
            }

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            ChecklistCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            ValidateRequired(row, errors, "EquipmentCode");
            ValidateRequired(row, errors, "InspectorCode");
            ValidateRequired(row, errors, "ChecklistTemplateCode");
            ValidateRequired(row, errors, "StandardCode");



            return Task.CompletedTask;
        }

        private static void ValidateRequired(
            Dictionary<string, string> row,
            List<string> errors,
            string columnName)
        {
            if (!row.TryGetValue(columnName, out var value)
                || string.IsNullOrWhiteSpace(value))
            {
                errors.Add($"{columnName} is required.");
            }
        }
    }
}
