using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.BankAccounts;
using Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.BankAccounts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.BankAccounts
{
    public class BankAccountQueryRepository : QueryRepositoryBase<BankAccount>, IBankAccountQueryRepository
    {
        public BankAccountQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<BankAccount?> GetById(long id)
        {
            return await _context.Set<BankAccount>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<BankAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CostUnitQueryRepository = new BankAccountQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CostUnitQueryRepository.Query(sqlQueryOptions);
        }
    }

}
