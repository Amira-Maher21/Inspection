using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Operations;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Operations
{
    public class OperationQueryRepository : QueryRepositoryBase<Operation>, IOperationQueryRepository
    {
        public OperationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<Operation?> GetById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Operation>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> HasOpenTransactions(long operationId)
        {
            return false;
        }

        public async Task<bool> HasAnyTransactions(long operationId)
        {
            return false;
        }
    }
}


