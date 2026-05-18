using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsTransferOuts
{
    public class GoodsTransferOutImportProfile : IImportProfile<GoodsTransferOutCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public GoodsTransferOutImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",

                "BranchCode",
                "WareHouseFromCode",
                "WareHouseToCode",

                "GoodsTransferOutDate",
                "Notes",
                "Posting",
                "ApprovalStatus"
            }.AsReadOnly();
        }

        public Task<GoodsTransferOutCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new GoodsTransferOutCreateDto
            {
                // CompanyId (Direct Parse)
                CompanyId = long.TryParse(
                    row.GetValueOrDefault("CompanyId"),
                    out var companyId)
                        ? companyId
                        : 0,

                GoodsTransferOutDate = DateTime.TryParse(
                    row.GetValueOrDefault("GoodsTransferOutDate"),
                    out var date)
                        ? date
                        : default,

                Notes = Normalize(row.GetValueOrDefault("Notes"))
            };

            //  Validate CompanyId format
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
            GoodsTransferOutCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required and must be valid.");

            if (dto.GoodsTransferOutDate == default)
                errors.Add("GoodsTransferOutDate is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("BranchCode")))
                errors.Add("BranchCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("WareHouseFromCode")))
                errors.Add("WareHouseFromCode is required.");

            return Task.CompletedTask;
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}