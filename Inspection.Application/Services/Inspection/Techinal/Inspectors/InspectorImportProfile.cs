using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inspection.Techinal.Inspectors
{
    public class InspectorImportProfile : IImportProfile<InspectorCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public InspectorImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyCode",
                "EmployeeCode",
                "User_Code",
                "InspectorCategoryCode",
                //"Code",
                "FirstName",
                "LastName",
                "Phone",
                "HireDate",
                "Disabled",
                "QualificationNotes",
                "Remarks"
            }.AsReadOnly();
        }

        public Task<InspectorCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new InspectorCreateDto
            {
                //Code = row.GetValueOrDefault("Code")?.Trim() ?? string.Empty,
                FirstName = row.GetValueOrDefault("FirstName")?.Trim() ?? string.Empty,
                LastName = row.GetValueOrDefault("LastName")?.Trim() ?? string.Empty,

                Phone = Normalize(row.GetValueOrDefault("Phone")),
                QualificationNotes = Normalize(row.GetValueOrDefault("QualificationNotes")),
                Remarks = Normalize(row.GetValueOrDefault("Remarks")),

                Disabled = ParseBool(row.GetValueOrDefault("Disabled"))
            };

            // Hire Date
            if (DateTime.TryParse(row.GetValueOrDefault("HireDate"), out var hireDate))
                dto.HireDate = hireDate;
            else if (!string.IsNullOrWhiteSpace(row.GetValueOrDefault("HireDate")))
                errors.Add("Invalid HireDate format.");

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            InspectorCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            ValidateRequired(row, errors, "CompanyCode");
            ValidateRequired(row, errors, "EmployeeCode");
            ValidateRequired(row, errors, "InspectorCategoryCode");
            //ValidateRequired(row, errors, "Code");
            ValidateRequired(row, errors, "FirstName");
            ValidateRequired(row, errors, "LastName");

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

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

        private static bool ParseBool(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;

            return value.Trim().ToLowerInvariant() is
                "1" or "true" or "yes" or "y";
        }
    }
}
