using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales.SalesOrderQuery;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Inspection.Infrastructure.QueryObjects.SalesManagment.sales.salesOrderQuery;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.sales
{
    public class SalesOrderQueryRepository : QueryRepositoryBase<SalesOrder>, ISalesOrderQueryRepository
    {

        public SalesOrderQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<SalesOrder?> GetByIdAsync(long id) => await _dbSet.Include(s => s.SalesOrderLines).FirstOrDefaultAsync(x => x.Id == id);



        public async Task<IEnumerable<SalesOrderDtoInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var SalesOrderQueryRep = new SalesOrderQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await SalesOrderQueryRep.Query(sqlQueryOptions);
            return result.Result;
        }



        public async Task<SalesOrder?> GetByCode(string code)
        {
            return await _context.Set<SalesOrder>().Where(x => x.OrderNumber == code).FirstOrDefaultAsync();
        }
    }
}
