using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues.GoodsIssueLines;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueCreateDto
    {
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public long? WarehouseId { get; set; }
        public DateTime GoodsIssueDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DocumentStatus DocumentStatus { get; set; }

        public virtual List<GoodsIssueLineCreateDto> GoodsIssueLines { get; set; } = new List<GoodsIssueLineCreateDto>();

    }
}
