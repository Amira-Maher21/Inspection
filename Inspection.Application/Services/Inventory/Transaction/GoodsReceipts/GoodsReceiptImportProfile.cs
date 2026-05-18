using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptImportProfile : IImportProfile<GoodsReceiptCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public GoodsReceiptImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",
                "BranchCode",
                "WarehouseCode",
                "GoodsReceiptDate",
                "Notes",
                "Posting"
            }.AsReadOnly();
        }

        public Task<GoodsReceiptCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new GoodsReceiptCreateDto
            {
                // CompanyId
                CompanyId = long.TryParse(
                    row.GetValueOrDefault("CompanyId"),
                    out var companyId)
                        ? companyId
                        : 0,

                // Date
                GoodsReceiptDate = DateTime.TryParse(
                    row.GetValueOrDefault("GoodsReceiptDate"),
                    out var date)
                        ? date
                        : default,

                // Notes
                Notes = Normalize(row.GetValueOrDefault("Notes"))
            };

            // Validate CompanyId format
            if (!string.IsNullOrWhiteSpace(row.GetValueOrDefault("CompanyId")) &&
                dto.CompanyId == 0)
            {
                errors.Add($"Invalid CompanyId '{row.GetValueOrDefault("CompanyId")}'");
            }

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

        public Task ValidateAsync(
            GoodsReceiptCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required and must be valid.");

            if (dto.GoodsReceiptDate == default)
                errors.Add("GoodsReceiptDate is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("BranchCode")))
                errors.Add("BranchCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("WarehouseCode")))
                errors.Add("WarehouseCode is required.");

            return Task.CompletedTask;
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}