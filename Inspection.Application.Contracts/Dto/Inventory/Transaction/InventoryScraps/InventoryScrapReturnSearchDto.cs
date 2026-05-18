using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Shared.ApprovalStatus;

namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps
{

    public class InventoryScrapReturnSearchDto
    {
        public long Id { get; private set; }

        public string Tenant_ID { get; set; }
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        public string InventoryScrapNumber { get; set; }



        public DateTime InventoryScrapDate { get; set; }

        public string? Notes { get; set; }

        public PostingEnum Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public long? SeriesId { get; private set; }
        public int RunningNumber { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        //// Navigation
        //public List<InventoryScrapLine> InventoryScrapLines { get; set; } = new();
    }
}
