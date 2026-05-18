using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.DebitNotes;
using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments.DebitNotes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments.DebitNotes
{
    public class DebitNoteQueryRepository : QueryRepositoryBase<DebitNote>, IDebitNoteQueryRepository
    {
        public DebitNoteQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<DebitNote>>> GetAll()
        {
            var result = await _context.Set<DebitNote>()
                .Include(x => x.DebitNoteLines)
                .Include(x => x.DebitNoteAdjustments)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<DebitNote>>.Success(result);
        }

        public async Task<DebitNote?> GetById(long id)
        {
            return await _context.Set<DebitNote>()
                .Include(x => x.DebitNoteLines)
                .Include(x => x.DebitNoteAdjustments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var debitNoteRepository = new DebitNoteQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await debitNoteRepository.Query(sqlQueryOptions);
        }
    }
}