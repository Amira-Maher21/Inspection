using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Accounting.AccountSetup.AccountingPeriods
{
    public class AccountingPeriodImportProfile : IImportProfile<AccountingPeriodCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public AccountingPeriodImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",
                "FiscalYearId",
                "Code",
                "Name",
                "StartDate",
                "EndDate",
                "LockDate",
                "IsClosed"
            }.AsReadOnly();
        }

        public Task<AccountingPeriodCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new AccountingPeriodCreateDto
            {
                CompanyId = ParseLong(row.GetValueOrDefault("CompanyId"), errors, "CompanyId"),
                FiscalYearId = ParseLong(row.GetValueOrDefault("FiscalYearId"), errors, "FiscalYearId"),
                Code = row.GetValueOrDefault("Code") ?? string.Empty,
                StartDate = ParseDate(row.GetValueOrDefault("StartDate"), errors, "StartDate"),
                EndDate = ParseDate(row.GetValueOrDefault("EndDate"), errors, "EndDate"),
                LockDate = ParseDate(row.GetValueOrDefault("LockDate"), errors, "LockDate"),
                IsClosed = ParseBool(row.GetValueOrDefault("IsClosed"), true)
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            AccountingPeriodCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required and must be greater than zero.");

            if (dto.FiscalYearId <= 0)
                errors.Add("FiscalYearId is required and must be greater than zero.");

            if (string.IsNullOrWhiteSpace(dto.Code))
                errors.Add("Code is required.");



            if (dto.StartDate == default)
                errors.Add("StartDate is required and must be a valid date.");

            if (dto.EndDate == default)
                errors.Add("EndDate is required and must be a valid date.");

            if (dto.StartDate >= dto.EndDate)
                errors.Add("StartDate must be earlier than EndDate.");

            if (dto.LockDate != default && dto.LockDate < dto.StartDate)
                errors.Add("LockDate cannot be earlier than StartDate.");

            return Task.CompletedTask;
        }

        // Helpers

        private static long ParseLong(
            string? value,
            List<string> errors,
            string columnName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errors.Add($"{columnName} is required.");
                return 0;
            }

            if (!long.TryParse(value, out var result))
            {
                errors.Add($"{columnName} must be a valid number.");
                return 0;
            }

            return result;
        }

        private static DateTime ParseDate(
            string? value,
            List<string> errors,
            string columnName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errors.Add($"{columnName} is required.");
                return default;
            }

            if (!DateTime.TryParse(value, out var result))
            {
                errors.Add($"{columnName} must be a valid date.");
                return default;
            }

            return result;
        }

        private static bool ParseBool(
            string? value,
            bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }
    }
}