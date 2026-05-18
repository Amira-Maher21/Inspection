using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueImportTemplateDto
    {
        public long CompanyId { get; set; }

        public string BranchCode { get; set; } = string.Empty;
        public string WarehouseCode { get; set; } = string.Empty;

        public DateTime GoodsIssueDate { get; set; }

        public string? Notes { get; set; }

        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}