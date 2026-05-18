using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models;
using Inspection.Domain.Models.Inventory.InventorySetup.Models;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Models
{
    public interface IModelQueryRepository : IQueryRepository<Model>
    {
        Task<ReturnBase<List<Model>>> GetAll();
        Task<Model?> GetById(long id);
        Task<Model?> GetByCode(string code);

        Task<ReturnBase<IEnumerable<ModelSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
