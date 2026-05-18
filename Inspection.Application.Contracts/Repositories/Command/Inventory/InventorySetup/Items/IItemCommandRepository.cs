using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Items
{
    public interface IItemCommandRepository : ICommandRepository<Item>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteItemReordersByItemId(long itemId);
        Task<ReturnBase> DeleteItemReordersByIds(List<long> ids);
    }
}