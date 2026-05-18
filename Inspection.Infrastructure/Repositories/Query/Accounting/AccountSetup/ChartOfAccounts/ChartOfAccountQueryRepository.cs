using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Infrastructure.QueryObjects.Accounting.ChartOfAccounts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.ChartOfAccounts
{
    public class ChartOfAccountQueryRepository : QueryRepositoryBase<ChartOfAccount>, IChartOfAccountQueryRepository
    {
        public ChartOfAccountQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ChartOfAccount?> GetById(long id)
        {
            return await _context.Set<ChartOfAccount>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ChartOfAccount?> GetByCode(string code)
        {
            return await _context.Set<ChartOfAccount>().Where(x => x.AccountCode == code).FirstOrDefaultAsync();
        }
        public async Task<ReturnBase<List<ChartOfAccount>>> GetAll()
        {
            var result = await _context.Set<ChartOfAccount>().AsNoTracking().ToListAsync();
            return ReturnBase<List<ChartOfAccount>>.Success(result);
        }

        public async Task<ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var chartOfAccountRepository = new ChartOfAccountQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await chartOfAccountRepository.Query(sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>> Select(SqlQueryOptions sqlQueryOptions)
        {
            var warehouseSelectQuery = new ChartOfAccountSelectQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await warehouseSelectQuery.Query(sqlQueryOptions);
        }
    }
}