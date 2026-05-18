using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Contracting.Setup.Activitys
{
    public class ActivityQueryRepository : QueryRepositoryBase<Activity>, IActivityQueryRepository
    {
        public ActivityQueryRepository(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Activity?> GetById(long id)
        {
            return await _dbSet
                .Include(x => x.Operation)
                .Include(x => x.WBS)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Activity>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet
                .Include(x => x.Operation)
                .Include(x => x.WBS)
                .ToListAsync();
        }

        public async Task<ReturnBase<IEnumerable<ActivityReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var activityQuery = new ActivityQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await activityQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}