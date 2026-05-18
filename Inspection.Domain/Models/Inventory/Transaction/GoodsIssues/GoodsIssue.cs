using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues.GoodsIssueLines;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Shared.ApprovalStatus;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssue : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string GoodsIssueNo { get; set; }



        public long BranchId { get; set; }
        public Branch Branch { get; set; }

        public long? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public DateTime GoodsIssueDate { get; set; }

        public string? Notes { get; set; }

        public PostingEnum? Posting { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DocumentStatus DocumentStatus { get; set; }

        // Lines
        public virtual List<GoodsIssueLine> GoodsIssueLines { get; set; } = new();

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}