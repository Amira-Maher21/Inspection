using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using Inspection.Domain.Models.Inventory.ItemGroups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query
{
    public interface IItemGroupQueryRepository : IQueryRepository<ItemGroup>
    {
        Task<ReturnBase<List<ItemGroup>>> GetAll();
        Task<ItemGroup?> GetById(long id);
        Task<ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
