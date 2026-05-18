using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem;
using Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountingSystem;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSystem
{
    public class DefaultAccountAssignmentQueryRepository : QueryRepositoryBase<DefaultAccountAssignment>, IDefaultAccountAssignmentQueryRepository
    {
        public DefaultAccountAssignmentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<DefaultAccountAssignment>>> GetAll()
        {
            var result = await _context.Set<DefaultAccountAssignment>().AsNoTracking().ToListAsync();
            return ReturnBase<List<DefaultAccountAssignment>>.Success(result);
        }

        public async Task<DefaultAccountAssignment?> GetById(long id)
        {
            return await _context.Set<DefaultAccountAssignment>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var DefaultAccountAssignmentRepository = new DefaultAccountAssignmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await DefaultAccountAssignmentRepository.Query(sqlQueryOptions);
        }


    }
}
