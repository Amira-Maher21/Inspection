using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs;
using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryOpeningBalances
{

    public interface IInventoryOpeningBalanceQueryRepository : IQueryRepository<InventoryOpeningBalance>
    {
        Task<ReturnBase<List<InventoryOpeningBalance>>> GetAll();
        Task<InventoryOpeningBalance?> GetById(long id);
        Task<ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}