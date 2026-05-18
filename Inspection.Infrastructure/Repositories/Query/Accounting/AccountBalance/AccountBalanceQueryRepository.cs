using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountBalances;
using Inspection.Domain.Models.Accounting.AccountBalance;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountBalances
{
    public class AccountBalanceQueryRepository : QueryRepositoryBase<AccountBalance>, IAccountBalanceQueryRepository
    {
        public AccountBalanceQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<AccountBalance?> GetById(long id)
        {
            return await _context.Set<AccountBalance>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        //public async Task<ReturnBase<IEnumerable<AccountBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        //{
        //    var CurrencyQueryRepository = new AccountBalanceQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    return await CurrencyQueryRepository.Query(sqlQueryOptions);
        //}
        public async Task<AccountBalance?> GetByItemAsync(string tenantId, long companyId, long? chartOfAccountId)
        {
            return await _context.Set<AccountBalance>()
                .Where(l => l.Tenant_ID == tenantId
                            && l.CompanyId == companyId
                            && l.ChartOfAccountId == chartOfAccountId)
                .FirstOrDefaultAsync();
        }
    }
}