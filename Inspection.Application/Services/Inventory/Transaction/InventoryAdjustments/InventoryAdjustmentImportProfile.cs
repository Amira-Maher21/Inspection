using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Services.Inventory.Transaction.InventoryAdjustments
{
    public class InventoryAdjustmentImportProfile : IImportProfile<InventoryAdjustmentCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }
        public InventoryAdjustmentImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",

                "BranchCode",
                "WareHouseCode",

                "InventoryAdjustmentDate",
                "Notes",
                "Posting",
                "ApprovalStatus"
            }.AsReadOnly();
        }

        public Task<InventoryAdjustmentCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new InventoryAdjustmentCreateDto
            {
                // ✅ CompanyId
                CompanyId = long.TryParse(
                    row.GetValueOrDefault("CompanyId"),
                    out var companyId)
                        ? companyId
                        : 0,

                InventoryAdjustmentDate = DateTime.TryParse(
                    row.GetValueOrDefault("InventoryAdjustmentDate"),
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
            InventoryAdjustmentCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required.");

            if (dto.InventoryAdjustmentDate == default)
                errors.Add("InventoryAdjustmentDate is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("BranchCode")))
                errors.Add("BranchCode is required.");


            return Task.CompletedTask;
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}