using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Accounting.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleImportProfile
        : IImportProfile<AssetDepreciationScheduleTampleteDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public AssetDepreciationScheduleImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "AssetCode",
                "PeriodYear",
                "PeriodMonth",
                "DepreciationAmount",
                "IsPosted"
            }.AsReadOnly();
        }

        public Task<AssetDepreciationScheduleTampleteDto?> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var assetCode = row.GetValueOrDefault("AssetCode")?.Trim();
            var yearStr = row.GetValueOrDefault("PeriodYear")?.Trim();
            var monthStr = row.GetValueOrDefault("PeriodMonth")?.Trim();
            var amountStr = row.GetValueOrDefault("DepreciationAmount")?.Trim();
            var isPostedStr = row.GetValueOrDefault("IsPosted")?.Trim();

            if (string.IsNullOrWhiteSpace(assetCode))
                errors.Add("AssetCode is required.");

            if (!int.TryParse(yearStr, out var periodYear))
                errors.Add("PeriodYear must be a valid year.");

            if (!int.TryParse(monthStr, out var periodMonth))
                errors.Add("PeriodMonth must be between 1 and 12.");

            if (!decimal.TryParse(amountStr, out var depreciationAmount))
                errors.Add("DepreciationAmount must be a valid decimal number.");

            bool isPosted = false;
            if (!string.IsNullOrWhiteSpace(isPostedStr))
            {
                if (!bool.TryParse(isPostedStr, out isPosted))
                    errors.Add("IsPosted must be true or false.");
            }

            if (errors.Any())
                return Task.FromResult<AssetDepreciationScheduleTampleteDto?>(null);

            return Task.FromResult(new AssetDepreciationScheduleTampleteDto
            {
                AssetCode = assetCode!,
                PeriodYear = periodYear,
                PeriodMonth = periodMonth,
                DepreciationAmount = depreciationAmount,
                IsPosted = isPosted
            });
        }

        public Task ValidateAsync(
            AssetDepreciationScheduleTampleteDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.PeriodMonth < 1 || dto.PeriodMonth > 12)
                errors.Add("PeriodMonth must be between 1 and 12.");

            if (dto.DepreciationAmount < 0)
                errors.Add("DepreciationAmount must be >= 0.");

            return Task.CompletedTask;
        }
    }
}
