using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashReceipts;
using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments.CashReceipts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CashReceipts
{
    public class CashReceiptQueryRepository : QueryRepositoryBase<CashReceipt>, ICashReceiptQueryRepository
    {
        public CashReceiptQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<CashReceipt>>> GetAll()
        {
            var result = await _context.Set<CashReceipt>()
                .Include(x => x.CashReceiptLines)
                .Include(x => x.CashReceiptAdjustments)
                .Include(x => x.SalesInvoiceAllocations)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<CashReceipt>>.Success(result);
        }

        public async Task<CashReceipt?> GetById(long id)
        {
            return await _context.Set<CashReceipt>()
                .Include(x => x.CashReceiptLines)
                .Include(x => x.CashReceiptAdjustments)
                .Include(x => x.SalesInvoiceAllocations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<CashReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var cashReceiptRepository = new CashReceiptQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await cashReceiptRepository.Query(sqlQueryOptions);
        }
    }
}
