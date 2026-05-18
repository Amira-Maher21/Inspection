using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using Inspection.Application.Contracts.Repositories.Query;
using Inspection.Domain.Models.Inventory.ItemGroups;
using Inspection.Infrastructure.QueryObjects.Inventory.ItemGroups;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.ItemGroups
{
    public class ItemGroupQueryRepository : QueryRepositoryBase<ItemGroup>, IItemGroupQueryRepository
    {
        public ItemGroupQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ItemGroup?> GetById(long id)
        {
            return await _context.Set<ItemGroup>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<ReturnBase<List<ItemGroup>>> GetAll()
        {
            var result = await _context.Set<ItemGroup>().AsNoTracking().ToListAsync();
            return ReturnBase<List<ItemGroup>>.Success(result);
        }

        public async Task<ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var itemGroupQueryRepository = new ItemGroupQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await itemGroupQueryRepository.Query(sqlQueryOptions);
        }
    }

}
