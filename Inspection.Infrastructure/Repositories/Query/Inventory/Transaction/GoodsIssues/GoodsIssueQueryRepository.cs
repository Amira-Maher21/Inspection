using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsIssues;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues;
using Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsIssues;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueQueryRepository : QueryRepositoryBase<GoodsIssue>, IGoodsIssueQueryRepository
    {
        public GoodsIssueQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager
        ) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<GoodsIssue?> GetById(long id)
        {
            return await _dbSet
                .Include(g => g.GoodsIssueLines)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<GoodsIssue?> GetByCode(string code)
        {
            return await _context.Set<GoodsIssue>()
                .FirstOrDefaultAsync(g => g.GoodsIssueNo == code);
        }

        public async Task<ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var goodsIssueQuery = new GoodsIssueQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await goodsIssueQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}