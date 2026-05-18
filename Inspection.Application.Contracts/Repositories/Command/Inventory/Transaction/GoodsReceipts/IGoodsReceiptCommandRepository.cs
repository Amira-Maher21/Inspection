using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsReceipts
{//IGoodsIssueCommandRepository
    public interface IGoodsReceiptCommandRepository : ICommandRepository<GoodsReceipt>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteGoodsReceiptLineByItemGoodsReceiptId(long GoodsReceiptId);
        Task<ReturnBase> DeleteGoodsReceiptLineByIds(List<long> ids);

    }
}