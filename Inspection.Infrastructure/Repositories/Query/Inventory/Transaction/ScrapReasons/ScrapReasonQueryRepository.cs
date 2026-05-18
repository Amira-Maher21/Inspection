using Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.ScrapReasons;
using Inspection.Domain.Models.Inventory.Transaction.ScrapReasons;
using Inspection.Infrastructure.QueryObjects.Inventory.Transaction.ScrapReasons;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonQueryRepository : QueryRepositoryBase<ScrapReason>, IScrapReasonQueryRepository
    {
        public ScrapReasonQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager
        ) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        // ================== GET BY ID ==================
        public async Task<ScrapReason?> GetById(long id)
        {
            return await _dbSet
                .Include(x => x.ChartOfAccount)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // ================== GET BY CODE ==================
        public async Task<ScrapReason?> GetByCode(string code)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        // ================== SEARCH ==================
        public async Task<ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var query = new ScrapReasonQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var result = await query.Query(sqlQueryOptions);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}