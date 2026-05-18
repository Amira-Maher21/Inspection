using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Banks;
using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Banks;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.Banks
{

    public class BankQueryRepository : QueryRepositoryBase<Bank>, IBankQueryRepository
    {
        public BankQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Bank?> GetById(long id)
        {
            return await _context.Set<Bank>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<BankDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CostUnitQueryRepository = new BankQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CostUnitQueryRepository.Query(sqlQueryOptions);
        }

    }

}
