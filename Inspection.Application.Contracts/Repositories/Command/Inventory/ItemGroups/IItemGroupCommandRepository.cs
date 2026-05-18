using Inspection.Domain.Models.Inventory.ItemGroups;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.ItemGroups
{
    public interface IItemGroupCommandRepository : ICommandRepository<ItemGroup>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);
        // Task<ItemGroup?> GetFirstChild(long parentId);
    }
}
