using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueReturnSearchDto
    {
        public long Id { get; set; }
        public string GoodsIssueNo { get; set; }

        public long CompanyId { get; set; }

        // Branch
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        // Warehouse
        public long? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseCode { get; set; }

        public DateTime GoodsIssueDate { get; set; }

        public string? Notes { get; set; }

        public PostingEnum Posting { get; set; }

        // Status
        public ApprovalStatus ApprovalStatus { get; set; }

        // Series
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Tenant & Audit
        public string Tenant_ID { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}