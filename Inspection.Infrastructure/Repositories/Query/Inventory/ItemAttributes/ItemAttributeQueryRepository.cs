using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.ItemAttributes;
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.ItemAttributes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.ItemAttributes
{
    public class ItemAttributeQueryRepository : QueryRepositoryBase<ItemAttribute>, IItemAttributeQueryRepository
    {
        public ItemAttributeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ItemAttribute?> GetById(long id)
        {
            return await _context.Set<ItemAttribute>()
                 .Include(x => x.ItemAttributeValues)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var itemAttributeRepository = new ItemAttributeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await itemAttributeRepository.Query(sqlQueryOptions);
        }
    }
}