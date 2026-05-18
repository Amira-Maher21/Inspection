using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryScraps;
using Inspection.Domain.Models.Inventory.Transaction.InventoryScraps;
using Inspection.Infrastructure.QueryObjects.Inventory.Transaction.InventoryScraps;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapQueryRepository
        : QueryRepositoryBase<InventoryScrap>, IInventoryScrapQueryRepository
    {
        public InventoryScrapQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager
        ) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<InventoryScrap?> GetById(long id)
        {
            return await _dbSet
                .Include(x => x.InventoryScrapLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<InventoryScrap?> GetByCode(string code)
        {
            return await _context.Set<InventoryScrap>()
                .FirstOrDefaultAsync(x => x.InventoryScrapNumber == code);
        }

        public async Task<ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var query = new InventoryScrapQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var result = await query.Query(sqlQueryOptions);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}