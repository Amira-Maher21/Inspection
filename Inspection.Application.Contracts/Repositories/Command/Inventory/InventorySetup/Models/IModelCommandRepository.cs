using Inspection.Domain.Models.Inventory.InventorySetup.Models;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Models
{
    public interface IModelCommandRepository : ICommandRepository<Model>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}

