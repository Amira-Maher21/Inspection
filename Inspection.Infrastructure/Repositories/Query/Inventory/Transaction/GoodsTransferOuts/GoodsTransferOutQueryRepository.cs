using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsTransferOuts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsTransferOuts
{
    public class GoodsTransferOutQueryRepository : QueryRepositoryBase<GoodsTransferOut>, IGoodsTransferOutQueryRepository
    {
        public GoodsTransferOutQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<GoodsTransferOut>>> GetAll()
        {
            var result = await _context.Set<GoodsTransferOut>()
                .Include(x => x.GoodsTransferOutLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<GoodsTransferOut>>.Success(result);
        }

        public async Task<GoodsTransferOut?> GetById(long id)
        {
            return await _context.Set<GoodsTransferOut>()
                .Include(x => x.GoodsTransferOutLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<GoodsTransferOut?> GetByGoodsTransferOutNumber(string goodsTransferOutNumber)
        {
            return await _context.Set<GoodsTransferOut>()
                .Include(x => x.GoodsTransferOutLines)
                .FirstOrDefaultAsync(x => x.GoodsTransferOutNumber == goodsTransferOutNumber);
        }

        public async Task<ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var goodsTransferOutRepository = new GoodsTransferOutQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await goodsTransferOutRepository.Query(sqlQueryOptions);
        }
    }
}