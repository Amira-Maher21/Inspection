using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Shared.ApprovalStatus;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrap : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;

        public string InventoryScrapNumber { get; set; } = string.Empty;





        public DateTime InventoryScrapDate { get; set; }

        public string? Notes { get; private set; }

        public PostingEnum Posting { get; private set; }
        public ApprovalStatus ApprovalStatus { get; private set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Navigation
        public List<InventoryScrapLine> InventoryScrapLines { get; set; } = new();
    }
}