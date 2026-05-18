using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferIns;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsTransferIns
{
    public interface IGoodsTransferInCommandRepository : ICommandRepository<GoodsTransferIn>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteGoodsTransferInLinesByIds(List<long> ids);
    }
}