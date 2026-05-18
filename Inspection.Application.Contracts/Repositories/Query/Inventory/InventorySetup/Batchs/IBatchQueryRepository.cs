using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Batchs;
using Inspection.Domain.Models.Inventory.InventorySetup.Batchs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Batchs
{
    public interface IBatchQueryRepository
    {
        Task<Batch?> GetById(long id);
        Task<IEnumerable<Batch>> GetList(SqlQueryOptions sqlQueryOptions = null);
        Task<ReturnBase<IEnumerable<BatchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
