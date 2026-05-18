using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.ItemGroups
{
    public class ItemGroup : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        //New
        public CostingMethodEnum CostingMethods { get; set; }

        public long? ParentGroupId { get; set; }

        public bool IsLeaf { get; set; }

        public bool IsSerialTracking { get; set; }
        public bool IsBatchTracking { get; set; }
        public bool IsExpiryTracking { get; set; }

        //Navigation Property FK
        public long? PurchaseAccountId { get; set; }
        public long? PurchaseReturnAccountId { get; set; }
        public long? SalesReturnAccountId { get; set; }
        public long? GoodsReceivedNotInvoicedAccountId { get; set; }
        public long? WipAccountId { get; set; }

        public long? InventoryAccountId { get; set; }
        public long? CogsAccountId { get; set; }
        public long? AdjustmentAccountId { get; set; }
        public long? RevenueAccountId { get; set; }

        public ChartOfAccount PurchaseReturnAccount { get; set; } = null!;
        public ChartOfAccount PurchaseAccount { get; set; } = null!;
        public ChartOfAccount SalesReturnAccount { get; set; } = null!;
        public ChartOfAccount GoodsReceivedNotInvoicedAccount { get; set; } = null!;
        public ChartOfAccount WipAccount { get; set; } = null!;
        public ChartOfAccount InventoryAccount { get; set; } = null!;
        public ChartOfAccount CogsAccount { get; set; } = null!;
        public ChartOfAccount AdjustmentAccount { get; set; } = null!;
        public ChartOfAccount RevenueAccount { get; set; } = null!;

        // series related
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}