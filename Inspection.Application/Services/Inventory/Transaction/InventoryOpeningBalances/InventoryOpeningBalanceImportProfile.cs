using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Services.Inventory.Transaction.InventoryOpeningBalances
{
    public class InventoryOpeningBalanceImportProfile : IImportProfile<InventoryOpeningBalanceCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public InventoryOpeningBalanceImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",
                "WarehouseCode",
                "FiscalYearCode",
                "BranchCode",
                "CurrencyCode",

                "Posting",
                "TotalValue",
                "YearEndCarryForward",
                "Description"
            }.AsReadOnly();
        }

        public Task<InventoryOpeningBalanceCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new InventoryOpeningBalanceCreateDto
            {
                CompanyId = long.TryParse(row.GetValueOrDefault("CompanyId"), out var companyId)
                    ? companyId
                    : 0,

                TotalValue = decimal.TryParse(row.GetValueOrDefault("TotalValue"), out var total)
                    ? total
                    : 0,

                //YearEndCarryForward = ParseBool(row.GetValueOrDefault("YearEndCarryForward")),

                Description = Normalize(row.GetValueOrDefault("Description"))
            };

            // Posting Enum
            var posting = row.GetValueOrDefault("Posting");
            if (!string.IsNullOrWhiteSpace(posting) &&
                Enum.TryParse<PostingEnum>(posting, true, out var postingEnum))
            {
                dto.Posting = postingEnum;
            }
            else if (!string.IsNullOrWhiteSpace(posting))
            {
                errors.Add($"Invalid Posting '{posting}'");
            }

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(InventoryOpeningBalanceCreateDto dto, Dictionary<string, string> row, List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required.");

            if (dto.TotalValue < 0)
                errors.Add("TotalValue must be >= 0.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("WarehouseCode")))
                errors.Add("WarehouseCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("FiscalYearCode")))
                errors.Add("FiscalYearCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("BranchCode")))
                errors.Add("BranchCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("CurrencyCode")))
                errors.Add("CurrencyCode is required.");

            return Task.CompletedTask;
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

        private static bool ParseBool(string? value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }
    }
}