using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public interface IUnitOfMeasureConversionQueryRepository : IQueryRepository<UnitOfMeasureConversion>
    {
        Task<ReturnBase<List<UnitOfMeasureConversion>>> GetAll();
        Task<UnitOfMeasureConversion?> GetById(long id);

        Task<ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}