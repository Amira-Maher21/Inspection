using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Items
{
    public interface IItemQueryRepository : IQueryRepository<Item>
    {
        Task<ReturnBase<List<Item>>> GetAll();
        Task<Item?> GetById(long id);
        Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> FilteredItem(SqlQueryOptions sqlQueryOptions);
        Task<Item?> GetByCode(string code);
    }
}