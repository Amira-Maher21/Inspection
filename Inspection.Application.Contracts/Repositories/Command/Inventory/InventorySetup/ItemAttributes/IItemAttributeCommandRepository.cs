using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.ItemAttributes
{
    public interface IItemAttributeCommandRepository : ICommandRepository<ItemAttribute>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteItemAttributeValuesByItemAttributeId(long itemAttributeId);
        Task<ReturnBase> DeleteItemAttributeValuesByItemAttributeIds(List<long> ids);
    }
}