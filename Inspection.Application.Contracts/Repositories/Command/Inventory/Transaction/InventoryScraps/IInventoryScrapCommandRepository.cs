using Inspection.Domain.Models.Inventory.Transaction.InventoryScraps;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryScraps
{
    public interface IInventoryScrapCommandRepository : ICommandRepository<InventoryScrap>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteInventoryScrapLineByIds(List<long> ids);
    }
}