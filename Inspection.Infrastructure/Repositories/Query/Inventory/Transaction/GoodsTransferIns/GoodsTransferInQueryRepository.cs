using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferIns;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferIns;
using Inspection.Infrastructure.QueryObjects.Inventory.Transaction.GoodsTransferIns;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsTransferIns
{
    public class GoodsTransferInQueryRepository : QueryRepositoryBase<GoodsTransferIn>, IGoodsTransferInQueryRepository
    {
        public GoodsTransferInQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<GoodsTransferIn>>> GetAll()
        {
            var result = await _context.Set<GoodsTransferIn>()
                .Include(x => x.GoodsTransferInLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<GoodsTransferIn>>.Success(result);
        }

        public async Task<GoodsTransferIn?> GetById(long id)
        {
            return await _context.Set<GoodsTransferIn>()
                .Include(x => x.GoodsTransferInLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<GoodsTransferIn?> GetByGoodsTransferInNumber(string goodsTransferInNumber)
        {
            return await _context.Set<GoodsTransferIn>()
                .Include(x => x.GoodsTransferInLines)
                .FirstOrDefaultAsync(x => x.GoodsTransferInNumber == goodsTransferInNumber);
        }

        public async Task<ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var goodsTransferInRepository = new GoodsTransferInQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await goodsTransferInRepository.Query(sqlQueryOptions);
        }
    }
}