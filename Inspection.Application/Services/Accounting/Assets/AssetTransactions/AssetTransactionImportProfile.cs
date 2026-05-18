using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Accounting.Assets.TransactionTypes;

namespace Inspection.Application.Services.Accounting.Assets.AssetTransactions
{
    public class AssetTransactionImportProfile : IImportProfile<AssetTransactionCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public AssetTransactionImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "FixedAssetCode",
                "TransactionType",
                "TransactionDate",
                "ReferenceId",
                "ReferenceType",
                "Notes"
            }.AsReadOnly();
        }

        public Task<AssetTransactionCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            TransactionTypeEnum transactionType = default;
            if (!Enum.TryParse<TransactionTypeEnum>(
                    row.GetValueOrDefault("TransactionType"),
                    true,
                    out transactionType))
            {
                errors.Add($"Invalid TransactionType: {row.GetValueOrDefault("TransactionType")}");
            }

            var dto = new AssetTransactionCreateDto
            {
                FixedAssetId = long.TryParse(row.GetValueOrDefault("FixedAssetCode"), out var assetId) ? assetId : 0,
                TransactionType = transactionType,
                TransactionDate = DateTime.TryParse(row.GetValueOrDefault("TransactionDate"), out var date) ? date : default,
                ReferenceId = long.TryParse(row.GetValueOrDefault("ReferenceId"), out var refId) ? refId : null,
                ReferenceType = row.GetValueOrDefault("ReferenceType")?.Trim() ?? string.Empty,
                Notes = row.GetValueOrDefault("Notes")?.Trim() ?? string.Empty
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            AssetTransactionCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.FixedAssetId <= 0)
                errors.Add("FixedAssetCode is required and must be a valid number.");

            if (dto.TransactionType == default)
                errors.Add("TransactionType is required or invalid.");

            if (dto.TransactionDate == default)
                errors.Add("TransactionDate is required.");

            if (!string.IsNullOrWhiteSpace(dto.ReferenceType) && dto.ReferenceType.Length > 100)
                errors.Add("ReferenceType must not exceed 100 characters.");

            if (!string.IsNullOrWhiteSpace(dto.Notes) && dto.Notes.Length > 250)
                errors.Add("Notes must not exceed 250 characters.");

            return Task.CompletedTask;
        }
    }
}
