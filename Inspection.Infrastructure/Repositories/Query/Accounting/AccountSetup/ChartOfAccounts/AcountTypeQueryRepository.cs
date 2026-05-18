using Inspection.Application.Contracts.Repositories.Query.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.ChartOfAccounts
{
    public class AcountTypeQueryRepository : QueryRepositoryBase<AccountType>, IAcountTypeQueryRepository
    {
        public AcountTypeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AccountType>>> GetAll()
        {
            try
            {
                var result = await _context.Set<AccountType>()
                                           .AsNoTracking()
                                           .ToListAsync();

                return ReturnBase<List<AccountType>>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AccountType>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<AccountType?> GetByCode(string code)
        {
            return await _context.Set<AccountType>().Where(x => x.AccountTypeCode == code).FirstOrDefaultAsync();
        }
    }
}