using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs;
using Inspection.Application.Contracts.Repositories.Query.Manufacturing.Setup.ProductionOrders;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Infrastructure.QueryObjects.Manufacturing.Setup.ProductionOrder;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Manufacturing.Setup.ProductionOrders
{
    public class ProductionOrderQueryRepository : QueryRepositoryBase<ProductionOrder>, IProductionOrderQueryRepository
    {
        public ProductionOrderQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<ProductionOrder>>> GetAll()
        {
            var result = await _context.Set<ProductionOrder>()
                .Include(x => x.ProductionOrderLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<ProductionOrder>>.Success(result);
        }

        public async Task<ProductionOrder?> GetById(long id)
        {
            return await _context.Set<ProductionOrder>()
                .Include(x => x.ProductionOrderLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var cashTransferRepository = new ProductionOrderQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await cashTransferRepository.Query(sqlQueryOptions);
        }
    }
}