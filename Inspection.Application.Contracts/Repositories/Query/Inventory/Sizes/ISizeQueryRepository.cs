using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using Inspection.Domain.Models.Inventory.InventorySetup.Sizes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Sizes
{
    public interface ISizeQueryRepository : IQueryRepository<Size>
    {
        Task<Size?> GetById(long id);
        Task<Size?> GetByCode(string code);

        Task<ReturnBase<IEnumerable<SizeDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }

}
