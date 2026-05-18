using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps;
using Inspection.Domain.Models.Inventory.Transaction.InventoryScraps;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryScraps
{
    public interface IInventoryScrapQueryRepository : IQueryRepository<InventoryScrap>
    {
        Task<InventoryScrap?> GetById(long id);
        Task<InventoryScrap?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
