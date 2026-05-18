using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs
{
    public class InventoryAdjustmentImportTemplateDto
    {
        public long CompanyId { get; set; }
        public string InventoryAdjustmentNumber { get; set; } = string.Empty;

        public string BranchCode { get; set; } = string.Empty;
        public string? WareHouseCode { get; set; }

        public DateTime InventoryAdjustmentDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}