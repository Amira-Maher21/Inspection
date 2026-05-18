using Inspection.Domain.Models.Inventory.InventorySetup.Batchs;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Batchs
{
    public interface IBatchCommandRepository : ICommandRepository<Batch>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
