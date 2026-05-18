using Inspection.Domain.Models.Inventory.InventorySetup.Brands;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Brands
{
    public interface IBrandCommandRepository : ICommandRepository<Brand>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}

