using Inspection.Application.Contracts.Dto.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup
{
    public interface IWarehouseQueryRepository : IQueryRepository<Warehouse>
    {
        Task<ReturnBase<List<Warehouse>>> GetAll();
        Task<Warehouse?> GetById(long id);

        Task<ReturnBase<IEnumerable<WarehouseReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<WarehouseSelectDto>>> Select(SqlQueryOptions sqlQueryOptions);

        Task<Warehouse?> GetByCode(string code);
    }
}
