using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales.SalesOrderQuery;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.sales
{
    public class SalesOrderItemQueryRepository : QueryRepositoryBase<SalesOrderLines>, ISalesOrderLineQueryRepository
    {

        public SalesOrderItemQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<SalesOrderLines?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);


        public async Task<List<SalesOrderLines>> GetListAsyncbySalesOrderId(long SalesOrderLineId) => await _dbSet.Where(x => x.Id == SalesOrderLineId).ToListAsync();


    }
}
