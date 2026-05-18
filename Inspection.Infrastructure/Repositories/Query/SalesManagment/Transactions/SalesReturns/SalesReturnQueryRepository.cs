using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesReturns;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns;
using Inspection.Infrastructure.QueryObjects.SalesManagment.SalesReturns;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.Transactions.SalesReturns
{
    public class SalesReturnQueryRepository
        : QueryRepositoryBase<SalesReturn>, ISalesReturnQueryRepository
    {
        public SalesReturnQueryRepository(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        // ================== GET ALL ==================
        public async Task<ReturnBase<List<SalesReturn>>> GetAll()
        {
            var result = await _context.Set<SalesReturn>()
                .Include(x => x.SalesReturnLines)
                .Include(x => x.SalesReturnAdjustments)
                .AsNoTracking()
                .ToListAsync();

            return ReturnBase<List<SalesReturn>>.Success(result);
        }

        // ================== GET BY ID ==================
        public async Task<SalesReturn?> GetById(long id)
        {
            return await _context.Set<SalesReturn>()
                .Include(x => x.SalesReturnLines)
                .Include(x => x.SalesReturnAdjustments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // ================== SEARCH ==================
        public async Task<ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var repo = new SalesReturnQuery(
                _queryBuilder,
                _dapper,
                _tenantResolver,
                _exceptionManager
            );

            return await repo.Query(sqlQueryOptions);
        }
    }
}