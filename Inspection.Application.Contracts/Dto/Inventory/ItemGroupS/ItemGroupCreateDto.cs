using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.Inventory.ItemGroupS
{
    public class ItemGroupCreateDto
    {

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? ParentGroupId { get; set; }
        public CostingMethodEnum CostingMethods { get; set; }


        public bool IsLeaf { get; set; }

        public bool IsSerialTracking { get; set; }
        public bool IsBatchTracking { get; set; }
        public bool IsExpiryTracking { get; set; }

        public long? PurchaseAccountId { get; set; }
        public long? PurchaseReturnAccountId { get; set; }
        public long? SalesReturnAccountId { get; set; }
        public long? GoodsReceivedNotInvoicedAccountId { get; set; }
        public long? WipAccountId { get; set; }

        public long? InventoryAccountId { get; set; }
        public long? CogsAccountId { get; set; }
        public long? AdjustmentAccountId { get; set; }
        public long? RevenueAccountId { get; set; }

    }
}
