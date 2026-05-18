using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments
{
    public class JournalEntryTemplateQueryRepository : QueryRepositoryBase<JournalEntryTemplate>, IJournalEntryTemplateQueryRepository
    {
        public JournalEntryTemplateQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<JournalEntryTemplate>>> GetAll()
        {
            var result = await _context.Set<JournalEntryTemplate>().Include(x => x.JournalEntryTemplateLines).AsNoTracking().ToListAsync();
            return ReturnBase<List<JournalEntryTemplate>>.Success(result);
        }

        public async Task<JournalEntryTemplate?> GetById(long id)
        {
            return await _context.Set<JournalEntryTemplate>()
                 .Include(x => x.JournalEntryTemplateLines)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<JournalEntryTemplate?> GetByNumber(string Number)
        {
            return await _context.Set<JournalEntryTemplate>().Where(x => x.JournalEntryTemplateNumber == Number).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var JournalEntryTemplateRepository = new JournalEntryTemplateQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await JournalEntryTemplateRepository.Query(sqlQueryOptions);
        }


    }
}