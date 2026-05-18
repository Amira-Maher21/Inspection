using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales.SalesOrderQuery
{
    public interface ISalesOrderQueryRepository : IQueryRepository<SalesOrder>
    {
        Task<SalesOrder?> GetByIdAsync(long id);
        Task<IEnumerable<SalesOrderDtoInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        Task<SalesOrder?> GetByCode(string code);
    }
}
