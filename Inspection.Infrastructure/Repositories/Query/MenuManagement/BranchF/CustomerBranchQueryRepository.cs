using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement.BranchF;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.BranchF
{
    public class CustomerBranchQueryRepository : QueryRepositoryBase<CustomerBranch>, ICustomerBranchQueryRepository
    {

        public CustomerBranchQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<CustomerBranch?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<CustomerBranchIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var BranchsQueryRepository = new CustomerBranchsQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await BranchsQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }
    }
}
