using Inspection.Domain.Models.Inventory.InventorySetup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.UnitOfMeasures
{
    public interface IUnitOfMeasureQueryRepository : IQueryRepository<UnitOfMeasure>
    {
        Task<ReturnBase<List<UnitOfMeasure>>> GetAll();
        Task<UnitOfMeasure?> GetById(long id);

        Task<ReturnBase<IEnumerable<UnitOfMeasure>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}