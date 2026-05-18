using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.Inventory.ItemGroupS
{
    public class ItemGroupDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? ParentGroupId { get; set; }
        public CostingMethodEnum CostingMethods { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsSerialTracking { get; set; }
        public bool IsBatchTracking { get; set; }
        public bool IsExpiryTracking { get; set; }


        //ChartOfAccount

        public long? PurchaseAccountId { get; set; }
        public long? PurchaseReturnAccountId { get; set; }
        public long? SalesReturnAccountId { get; set; }
        public long? GoodsReceivedNotInvoicedAccountId { get; set; }
        public long? WipAccountId { get; set; }
        public long? InventoryAccountId { get; set; }
        public long? CogsAccountId { get; set; }
        public long? AdjustmentAccountId { get; set; }
        public long? RevenueAccountId { get; set; }


        //Series
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        //Auditable
        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
