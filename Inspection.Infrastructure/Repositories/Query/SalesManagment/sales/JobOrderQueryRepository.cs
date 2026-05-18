using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Inspection.Infrastructure.QueryObjects.SalesManagment.sales;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.sales
{
    public class JobOrderQueryRepository : QueryRepositoryBase<JobOrder>, IJobOrderQueryRepository
    {
        public JobOrderQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<JobOrder?> GetByIdAsync(long id) => await _dbSet.Include(j => j.JobOrderLines).FirstOrDefaultAsync(x => x.Id == id);


        public async Task<IEnumerable<JobOrderIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var JobOrderQueryRep = new JobOrderQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await JobOrderQueryRep.Query(sqlQueryOptions);
            return result.Result;
        }
        public async Task<ReturnBase<IEnumerable<JobOrderIncludeDto>>> GetLookUpJobOrderForNamesAsync(SqlQueryOptions queryOptions)
        {
            var JobOrderQueryRepository = new JobOrderQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await JobOrderQueryRepository.Query(queryOptions);

        }
    }
}