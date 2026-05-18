using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CreditNotes;
using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments.CreditNotes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CreditNotes
{
    public class CreditNoteQueryRepository : QueryRepositoryBase<CreditNote>, ICreditNoteQueryRepository
    {
        public CreditNoteQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<CreditNote>>> GetAll()
        {
            var result = await _context.Set<CreditNote>()
                .Include(x => x.CreditNoteLines)
                .Include(x => x.CreditNoteAdjustments)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<CreditNote>>.Success(result);
        }

        public async Task<CreditNote?> GetById(long id)
        {
            return await _context.Set<CreditNote>()
                .Include(x => x.CreditNoteLines)
                .Include(x => x.CreditNoteAdjustments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<CreditNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var creditNoteRepository = new CreditNoteQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await creditNoteRepository.Query(sqlQueryOptions);
        }
    }
}