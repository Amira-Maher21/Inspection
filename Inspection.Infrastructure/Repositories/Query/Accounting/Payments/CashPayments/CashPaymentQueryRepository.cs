using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashPayments;
using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments.CashPayments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CashPayments
{
    public class CashPaymentQueryRepository : QueryRepositoryBase<CashPayment>, ICashPaymentQueryRepository
    {
        public CashPaymentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<CashPayment>>> GetAll()
        {
            var result = await _context.Set<CashPayment>()
                .Include(x => x.CashPaymentLines)
                .Include(x => x.CashPaymentAdjustments)
                .Include(x => x.PurchaseInvoiceAllocations)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<CashPayment>>.Success(result);
        }

        public async Task<CashPayment?> GetById(long id)
        {
            return await _context.Set<CashPayment>()
                .Include(x => x.CashPaymentLines)
                .Include(x => x.CashPaymentAdjustments)
                .Include(x => x.PurchaseInvoiceAllocations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var cashPaymentRepository = new CashPaymentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await cashPaymentRepository.Query(sqlQueryOptions);
        }
    }
}