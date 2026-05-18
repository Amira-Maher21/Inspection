using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales.SalesOrderQuery
{
    public interface ISalesOrderLineQueryRepository : IQueryRepository<SalesOrderLines>
    {
        Task<SalesOrderLines?> GetByIdAsync(long id);

    }
}
