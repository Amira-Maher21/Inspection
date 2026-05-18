using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Cashing;
using Inspection.Domain.Models.Accounting.AccountingSetup.Cashing;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Cashing;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.Cashing
{
    public class CashQueryRepository : QueryRepositoryBase<Cash>, ICashQueryRepository
    {
        public CashQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Cash>>> GetAll()
        {
            var result = await _context.Set<Cash>().AsNoTracking().ToListAsync();
            return ReturnBase<List<Cash>>.Success(result);
        }

        public async Task<Cash?> GetById(long id)
        {
            return await _context.Set<Cash>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<CashReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CashRepository = new CashQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CashRepository.Query(sqlQueryOptions);
        }


    }
}
