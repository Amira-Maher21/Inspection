using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueImportProfile : IImportProfile<GoodsIssueCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public GoodsIssueImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",
                "BranchCode",
                "WarehouseCode",
                "GoodsIssueDate",
                "Notes",
                "Posting",
                "ApprovalStatus",
                "DocumentStatus"
            }.AsReadOnly();
        }

        public Task<GoodsIssueCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new GoodsIssueCreateDto
            {
                // CompanyId
                CompanyId = long.TryParse(
                    row.GetValueOrDefault("CompanyId"),
                    out var companyId)
                        ? companyId
                        : 0,

                // Date
                GoodsIssueDate = DateTime.TryParse(
                    row.GetValueOrDefault("GoodsIssueDate"),
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
            var postingValue = row.GetValueOrDefault("Posting");
            if (!string.IsNullOrWhiteSpace(postingValue) &&
                Enum.TryParse<PostingEnum>(postingValue, true, out var postingEnum))
            {
                dto.Posting = postingEnum;
            }
            else if (!string.IsNullOrWhiteSpace(postingValue))
            {
                errors.Add($"Invalid Posting '{postingValue}'");
            }

            // ✅ ApprovalStatus Enum (FIXED)
            var approvalValue = row.GetValueOrDefault("ApprovalStatus");

            if (!string.IsNullOrWhiteSpace(approvalValue) &&
                Enum.TryParse<ApprovalStatus>(approvalValue, true, out var approvalEnum))
            {
                dto.ApprovalStatus = approvalEnum;
            }
            else if (!string.IsNullOrWhiteSpace(approvalValue))
            {
                errors.Add($"Invalid ApprovalStatus '{approvalValue}'");
            }



            // ✅ DocumentStatus Enum
            var documentStatusValue = row.GetValueOrDefault("DocumentStatus");

            if (!string.IsNullOrWhiteSpace(documentStatusValue) &&
                Enum.TryParse<DocumentStatus>(documentStatusValue, true, out var docStatusEnum))
            {
                dto.DocumentStatus = docStatusEnum;
            }
            else if (!string.IsNullOrWhiteSpace(documentStatusValue))
            {
                errors.Add($"Invalid DocumentStatus '{documentStatusValue}'");
            }


            return Task.FromResult(dto);
        }

        // ✅ FIXED SIGNATURE
        public Task ValidateAsync(
            GoodsIssueCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required and must be valid.");

            if (dto.GoodsIssueDate == default)
                errors.Add("GoodsIssueDate is required.");

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