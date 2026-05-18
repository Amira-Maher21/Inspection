using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.AccountingPeriods;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.AccountingPeriods
{
    public class AccountingPeriodQueryRepository : QueryRepositoryBase<AccountingPeriod>, IAccountingPeriodQueryRepository
    {
        public AccountingPeriodQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<AccountingPeriod?> GetById(long id)
        {
            return await _context.Set<AccountingPeriod>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var accountingPeriodRepository = new AccountingPeriodQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await accountingPeriodRepository.Query(sqlQueryOptions);
        }
        public IQueryable<AccountingPeriod> GetAll()
        {
            return _context.Set<AccountingPeriod>().AsQueryable();
        }

    }
}