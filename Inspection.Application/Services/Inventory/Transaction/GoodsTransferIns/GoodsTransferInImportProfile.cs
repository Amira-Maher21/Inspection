using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsTransferIns
{
    public class GoodsTransferInImportProfile : IImportProfile<GoodsTransferInCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public GoodsTransferInImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",

                "BranchCode",
                "GoodsTransferOutNumber",   // important FK
                "WareHouseCode",

                "GoodsTransferInDate",
                "Notes",
                "Posting",
                "ApprovalStatus"
            }.AsReadOnly();
        }

        public Task<GoodsTransferInCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new GoodsTransferInCreateDto
            {
                // ✅ CompanyId
                CompanyId = long.TryParse(
                    row.GetValueOrDefault("CompanyId"),
                    out var companyId)
                        ? companyId
                        : 0,

                GoodsTransferInDate = DateTime.TryParse(
                    row.GetValueOrDefault("GoodsTransferInDate"),
                    out var date)
                        ? date
                        : default,

                Notes = Normalize(row.GetValueOrDefault("Notes"))
            };

            // CompanyId validation
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

            // Approval Status Enum
            var approval = row.GetValueOrDefault("ApprovalStatus");
            if (!string.IsNullOrWhiteSpace(approval) &&
                Enum.TryParse<ApprovalStatus>(approval, true, out var approvalEnum))
            {
                dto.ApprovalStatus = approvalEnum;
            }
            else if (!string.IsNullOrWhiteSpace(approval))
            {
                errors.Add($"Invalid ApprovalStatus '{approval}'");
            }

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            GoodsTransferInCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required.");

            if (dto.GoodsTransferInDate == default)
                errors.Add("GoodsTransferInDate is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("BranchCode")))
                errors.Add("BranchCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("GoodsTransferOutNumber")))
                errors.Add("GoodsTransferOutNumber is required.");

            return Task.CompletedTask;
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}