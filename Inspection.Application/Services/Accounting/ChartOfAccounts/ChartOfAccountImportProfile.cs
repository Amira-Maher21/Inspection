using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Accounting.ChartOfAccounts
{
    public class ChartOfAccountImportProfile : IImportProfile<ChartOfAccountCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public ChartOfAccountImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "AccountCode",
                "AccountName",
                "ParentAccountCode",
                "AccountTypeCode",
                "CurrencyCode",
                "CostUnitCode",
                "CostCenterCode",
                "IsMain",
                "IsCostCenterRequired",
                "IsCostUnitRequired",
                "IsDisable",
                "IsControlAccount",
                "IsReconciliationAccount",
                "IsCashAccount",
                "IsBankAccount"
            }.AsReadOnly();
        }

        public Task<ChartOfAccountCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new ChartOfAccountCreateDto
            {
                AccountCode = row.GetValueOrDefault("AccountCode")?.Trim() ?? string.Empty,
                AccountName = row.GetValueOrDefault("AccountName")?.Trim() ?? string.Empty,
                AccountTypeCode = row.GetValueOrDefault("AccountTypeCode")?.Trim() ?? string.Empty,

                IsMain = ParseBool(row.GetValueOrDefault("IsMain")),
                IsCostCenterRequired = ParseBool(row.GetValueOrDefault("IsCostCenterRequired")),
                IsCostUnitRequired = ParseBool(row.GetValueOrDefault("IsCostUnitRequired")),
                IsDisable = ParseBool(row.GetValueOrDefault("IsDisable")),
                IsControlAccount = ParseBool(row.GetValueOrDefault("IsControlAccount")),
                IsReconciliationAccount = ParseBool(row.GetValueOrDefault("IsReconciliationAccount")),
                IsCashAccount = ParseBool(row.GetValueOrDefault("IsCashAccount")),
                IsBankAccount = ParseBool(row.GetValueOrDefault("IsBankAccount"))
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            ChartOfAccountCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.AccountCode))
                errors.Add("AccountCode is required.");

            if (string.IsNullOrWhiteSpace(dto.AccountName))
                errors.Add("AccountName is required.");

            if (string.IsNullOrWhiteSpace(dto.AccountTypeCode))
                errors.Add("AccountTypeCode is required.");

            return Task.CompletedTask;
        }

        private static bool ParseBool(string? value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }
    }
}