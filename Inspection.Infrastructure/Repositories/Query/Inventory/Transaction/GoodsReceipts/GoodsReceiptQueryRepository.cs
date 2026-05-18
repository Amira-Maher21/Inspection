using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsReceipts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptQueryRepository : QueryRepositoryBase<GoodsReceipt>, IGoodsReceiptQueryRepository
    {
        public GoodsReceiptQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<GoodsReceipt>>> GetAll()
        {
            var result = await _context.Set<GoodsReceipt>().Include(x => x.GoodsReceiptLines).AsNoTracking().ToListAsync();
            return ReturnBase<List<GoodsReceipt>>.Success(result);
        }

        public async Task<GoodsReceipt?> GetById(long id)
        {
            return await _context.Set<GoodsReceipt>()
                 .Include(x => x.GoodsReceiptLines)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var GoodsReceiptRepository = new GoodsReceiptQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await GoodsReceiptRepository.Query(sqlQueryOptions);
        }
    }
}