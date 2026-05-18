using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.JournalEntrys;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments.JournalEntrys;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments.JournalEntrys
{

    public class JournalEntryQueryRepository : QueryRepositoryBase<JournalEntry>, IJournalEntryQueryRepository
    {
        public JournalEntryQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<JournalEntry?> GetById(long id)
        {
            return await _dbSet
                .Include(s => s.JournalEntryLines)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var journalEntryQueryRepo = new JournalEntryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await journalEntryQueryRepo.Query(sqlQueryOptions);
        }


        public async Task<JournalEntry?> GetByCode(string code)
        {
            return await _context.Set<JournalEntry>().Where(x => x.JournalNo == code).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<JournalEntry>> GetUnpostedDocumentsAsync()
        {
            return await _context.Set<JournalEntry>()
                .Include(je => je.JournalEntryLines)
                .Where(je => je.Posting == PostingEnum.Draft)
                .ToListAsync();
        }
    }
}
