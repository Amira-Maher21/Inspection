using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs;
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.ItemAttributes
{
    public interface IItemAttributeQueryRepository : IQueryRepository<ItemAttribute>
    {
        Task<ItemAttribute?> GetById(long id);
        Task<ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}