using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.SalesInvoices;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Inspection.Infrastructure.QueryObjects.Accounting.AR.SalesInvoices;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AR.SalesInvoices
{

    public class SalesInvoiceQueryRepository : QueryRepositoryBase<SalesInvoice>, ISalesInvoiceQueryRepository
    {

        public SalesInvoiceQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<ReturnBase<List<SalesInvoiceLine>>> GetAll()
        {
            var result = await _context.Set<SalesInvoiceLine>()
                 .AsNoTracking().ToListAsync();
            return ReturnBase<List<SalesInvoiceLine>>.Success(result);
        }


        public async Task<SalesInvoice?> GetByCode(string code)
        {
            return await _context.Set<SalesInvoice>()
                .FirstOrDefaultAsync(x => x.InvoiceNo == code);
        }



        public async Task<SalesInvoice?> GetById(long id)
        {
            return await _dbSet
                .Include(c => c.SalesInvoiceLines)
                .Include(c => c.SalesInvoiceSalesAdjustments)
                .Include(c => c.SalesInvoiceSalesPersons)
                .FirstOrDefaultAsync(c => c.Id == id);
        }





        public async Task<ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)

        {
            try
            {
                var customerQuery = new SalesInvoiceQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await customerQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



    }
}
