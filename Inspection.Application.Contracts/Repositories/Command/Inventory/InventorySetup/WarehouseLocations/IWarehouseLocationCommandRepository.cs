using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.WarehouseLocations
{
    public interface IWarehouseLocationCommandRepository : ICommandRepository<WarehouseLocation>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);
    }
}
