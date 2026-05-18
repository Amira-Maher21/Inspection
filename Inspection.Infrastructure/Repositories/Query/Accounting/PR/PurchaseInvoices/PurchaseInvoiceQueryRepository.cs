using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Repositories.Query.Accounting.PR.PurchaseInvoices;
using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using Inspection.Infrastructure.QueryObjects.Accounting.PR.PurchaseInvoices;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceQueryRepository : QueryRepositoryBase<PurchaseInvoice>, IPurchaseInvoiceQueryRepository
    {
        public PurchaseInvoiceQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager)
            : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<PurchaseInvoice?> GetByCode(string code)
        {
            return await _context.Set<PurchaseInvoice>()
                .FirstOrDefaultAsync(x => x.InvoiceNo == code);
        }

        public async Task<PurchaseInvoice?> GetById(long id)
        {
            return await _dbSet
                .Include(c => c.InvoiceLines)
                .Include(c => c.Adjustments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var purchaseInvoiceQuery = new PurchaseInvoiceQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await purchaseInvoiceQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}