using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs.InventoryAdjustmentLineDTOs;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs
{
    public class InventoryAdjustmentUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public long? WareHouseId { get; set; }

        public DateTime InventoryAdjustmentDate { get; set; }
        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public List<InventoryAdjustmentLineUpdateDto> InventoryAdjustmentLines { get; set; } = null!;
    }
}