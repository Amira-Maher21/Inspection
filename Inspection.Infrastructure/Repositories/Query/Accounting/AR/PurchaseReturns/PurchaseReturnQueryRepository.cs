using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.PurchaseReturns;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns;
using Inspection.Infrastructure.QueryObjects.Accounting.AR.PurchaseReturns;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AR.PurchaseReturns
{
    public class PurchaseReturnQueryRepository : QueryRepositoryBase<PurchaseReturn>, IPurchaseReturnQueryRepository
    {
        public PurchaseReturnQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<PurchaseReturn>>> GetAll()
        {
            var result = await _context.Set<PurchaseReturn>()
                .Include(x => x.PurchaseReturnLines)
                .Include(x => x.PurchaseReturnAdjustments)
                 .AsNoTracking().ToListAsync();
            return ReturnBase<List<PurchaseReturn>>.Success(result);
        }

        public async Task<PurchaseReturn?> GetById(long id)
        {
            return await _context.Set<PurchaseReturn>()
                .Include(x => x.PurchaseReturnLines)
                .Include(x => x.PurchaseReturnAdjustments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var PurchaseReturnRepository = new PurchaseReturnQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await PurchaseReturnRepository.Query(sqlQueryOptions);
        }
    }
}
