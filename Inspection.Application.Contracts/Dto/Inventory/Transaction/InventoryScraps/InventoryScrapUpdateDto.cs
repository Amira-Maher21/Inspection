using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps.InventoryScrapLines;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapUpdateDto
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }

        public long BranchId { get; set; }




        public DateTime InventoryScrapDate { get; set; }

        public string? Notes { get; set; }

        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }





        // Navigation
        public List<InventoryScrapLineUpdateDto> InventoryScrapLines { get; set; } = new();
    }
}
