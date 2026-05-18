using Inspection.Domain.Event;

namespace Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptPostedEvent : IPostingEvent
    {
        public long DocId { get; }
        public string TenantId { get; }
        public string UserId { get; }
        public DateTime OccurredOn { get; }

        public GoodsReceiptPostedEvent(
            long goodsReceiptId,
            string tenantId,
            string userId)
        {
            DocId = goodsReceiptId;
            TenantId = tenantId;
            UserId = userId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
