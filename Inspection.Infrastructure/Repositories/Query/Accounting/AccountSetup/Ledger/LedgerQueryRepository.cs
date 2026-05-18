using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.LedgerQueryRepository;
using Inspection.Domain.Models.Inventory.Ledger;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Ledger;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.LedgerQueryRepository
{
    public class LedgerQueryRepository : QueryRepositoryBase<Ledger>, ILedgerQueryRepository
    {

        public LedgerQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<Ledger?> GetByIdAsync(long id) => await _dbSet.Include(s => s.LedgerLines).FirstOrDefaultAsync(x => x.Id == id);



        public async Task<IEnumerable<LedgerDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var LedgerQueryRep = new LedgerQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await LedgerQueryRep.Query(sqlQueryOptions);
            return result.Result;
        }

        //public async Task<IEnumerable<ViewEntryLedgerDto?>> GetLedgerLinesByDocumentAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    var LedgerQueryRep = new GetLedgerLineQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    var result = await LedgerQueryRep.Query(sqlQueryOptions);
        //    return result.Result;
        //}

        public async Task<IEnumerable<ViewEntryLedgerDto?>> GetLedgerLinesByDocumentAsync(SqlQueryOptions sqlQueryOptions)
        {

            var ledgerQuery = new GetLedgerLineQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            var result = await ledgerQuery.Query(sqlQueryOptions);

            return result.Result ?? Enumerable.Empty<ViewEntryLedgerDto>();
        }
    }
}
