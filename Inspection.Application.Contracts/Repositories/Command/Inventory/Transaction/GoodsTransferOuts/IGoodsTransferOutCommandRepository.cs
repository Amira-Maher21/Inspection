using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsTransferOuts
{
    public interface IGoodsTransferOutCommandRepository : ICommandRepository<GoodsTransferOut>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteGoodsTransferOutLinesByIds(List<long> ids);
    }
}