using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Domain.Models.Inventory.System.InventoryBalances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryBalances
{
    public interface IInventoryBalanceQueryRepository : IQueryRepository<InventoryBalance>
    {
        Task<ReturnBase<List<InventoryBalance>>> GetAll();
        Task<InventoryBalance?> GetById(long id);

        Task<ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<InventoryBalance?> GetByKey(long itemId, long warehouseId, long? locationId);

    }
}
