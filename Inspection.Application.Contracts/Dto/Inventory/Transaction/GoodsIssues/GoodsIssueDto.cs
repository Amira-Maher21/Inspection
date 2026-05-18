using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues.GoodsIssueLines;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueDto
    {
        public long Id { get; set; }
        public string GoodsIssueNo { get; set; }
        public long BranchId { get; set; }
        public long? WarehouseId { get; set; }
        public DateTime GoodsIssueDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DocumentStatus DocumentStatus { get; set; }

        public virtual List<GoodsIssueLineDto> GoodsIssueLines { get; set; } = new List<GoodsIssueLineDto>();

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        // Series
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }

}
