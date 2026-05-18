using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Items;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Items
{
    public class ItemQueryRepository : QueryRepositoryBase<Item>, IItemQueryRepository
    {
        public ItemQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Item>>> GetAll()
        {
            var result = await _context.Set<Item>()
                .Include(x => x.ItemReordersPerWarehouse)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<Item>>.Success(result);
        }

        public async Task<Item?> GetById(long id)
        {
            return await _context.Set<Item>()
                 .Include(x => x.ItemReordersPerWarehouse)
                 //.Include(x => x.VariantAttributes)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var itemRepository = new ItemQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await itemRepository.Query(sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> FilteredItem(SqlQueryOptions sqlQueryOptions)
        {
            var itemRepository = new ItemFilteredQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await itemRepository.Query(sqlQueryOptions);
        }



        public async Task<Item?> GetByCode(string code)
        {
            return await _context.Set<Item>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}