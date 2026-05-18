using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashTransfers;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments.CashTransfers;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CashTransfers
{
    public class CashTransferQueryRepository : QueryRepositoryBase<CashTransfer>, ICashTransferQueryRepository
    {
        public CashTransferQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<CashTransfer>>> GetAll()
        {
            var result = await _context.Set<CashTransfer>()
                .Include(x => x.CashTransferLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<CashTransfer>>.Success(result);
        }

        public async Task<CashTransfer?> GetById(long id)
        {
            return await _context.Set<CashTransfer>()
                .Include(x => x.CashTransferLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<CashTransferReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var cashTransferRepository = new CashTransferQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await cashTransferRepository.Query(sqlQueryOptions);
        }
    }
}