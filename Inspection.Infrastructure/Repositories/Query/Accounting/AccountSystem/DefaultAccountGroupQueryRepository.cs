using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem;
using Inspection.Domain.Models.Accounting.AccountingSystem;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSystem;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSystem
{
    internal class DefaultAccountGroupQueryRepository : QueryRepositoryBase<DefaultAccountGroup>, IDefaultAccountGroupQueryRepository
    {
        public DefaultAccountGroupQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<DefaultAccountGroup>>> GetAll()
        {
            var result = await _context.Set<DefaultAccountGroup>().AsNoTracking().ToListAsync();
            return ReturnBase<List<DefaultAccountGroup>>.Success(result);
        }

        public async Task<DefaultAccountGroup?> GetById(long id)
        {
            return await _context.Set<DefaultAccountGroup>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<DefaultAccountGroup>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var DefaultAccountGroupRepository = new DefaultAccountGroupQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await DefaultAccountGroupRepository.Query(sqlQueryOptions);
        }


    }
}