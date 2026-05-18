using Inspection.Domain.Models.Inventory.InventorySetup.Brands;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Brands
{
    public interface IBrandQueryRepository : IQueryRepository<Brand>
    {
        Task<ReturnBase<List<Brand>>> GetAll();
        Task<Brand?> GetById(long id);
        Task<Brand?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<Brand>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
