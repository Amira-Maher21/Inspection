using Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public interface IUnitOfMeasureConversionCommandRepository : ICommandRepository<UnitOfMeasureConversion>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}