using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.FiscalYears;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.FiscalYears
{
    public class FiscalYearQueryRepository : QueryRepositoryBase<FiscalYear>, IFiscalYearQueryRepository
    {
        public FiscalYearQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<FiscalYear?> GetById(long id)
        {
            return await _context.Set<FiscalYear>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ReturnBase<IEnumerable<FiscalYearDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var FiscalYearQueryRepository = new FiscalYearQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await FiscalYearQueryRepository.Query(sqlQueryOptions);
        }
        public async Task<FiscalYear?> GetByCode(string code)
        {
            return await _context.Set<FiscalYear>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }


    }
}