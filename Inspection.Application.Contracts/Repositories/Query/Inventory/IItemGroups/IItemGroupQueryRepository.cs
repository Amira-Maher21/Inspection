using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using Inspection.Domain.Models.Inventory.ItemGroups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.IItemGroups
{

    public interface IItemGroupQueryRepository
    {
        Task<ItemGroup?> GetById(long id);
        Task<ReturnBase<IEnumerable<ItemGroupDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}