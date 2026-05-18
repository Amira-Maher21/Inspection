using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.WarehouseLocations
{
    public interface IWarehouseLocationQueryRepository : IQueryRepository<WarehouseLocation>
    {
        Task<WarehouseLocation?> GetById(long id);
        Task<WarehouseLocation?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<WarehouseLocationSelectDto>>> Select(SqlQueryOptions sqlQueryOptions);


    }
}
