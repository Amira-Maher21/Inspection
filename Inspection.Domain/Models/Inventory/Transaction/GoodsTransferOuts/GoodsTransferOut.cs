using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Shared.ApprovalStatus;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts
{
    public class GoodsTransferOut : IRootEntity, ITenantEntity, IAuditable, ISeries
    {
        public long Id { get; private set; }

        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        // Document No
        public string GoodsTransferOutNumber { get; set; } = string.Empty;

        // Relations
        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;

        public long WareHouseFromId { get; private set; }
        public Warehouse WareHouseFrom { get; private set; } = null!;

        public long? WareHouseId { get; private set; }
        public Warehouse? WareHouse { get; private set; }

        // Dates
        public DateTime GoodsTransferOutDate { get; private set; }

        // Description
        public string? Notes { get; private set; }

        // Status
        public PostingEnum Posting { get; private set; }
        public ApprovalStatus ApprovalStatus { get; private set; }

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // Details
        public List<GoodsTransferOutLine> GoodsTransferOutLines { get; set; } = null!;
    }
}