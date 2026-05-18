using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps.InventoryScrapLines;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; }
        public long CompanyId { get; set; }

        public long BranchId { get; set; }

        public string InventoryScrapNumber { get; set; }



        public DateTime InventoryScrapDate { get; set; }

        public string? Notes { get; set; }

        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Navigation
        public List<InventoryScrapLineDto> InventoryScrapLines { get; set; } = new();
    }
}
