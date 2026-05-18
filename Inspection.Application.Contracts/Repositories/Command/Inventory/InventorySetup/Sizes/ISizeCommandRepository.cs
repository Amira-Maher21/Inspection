using Inspection.Domain.Models.Inventory.InventorySetup.Sizes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Sizes
{
    public interface ISizeCommandRepository : ICommandRepository<Size>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
