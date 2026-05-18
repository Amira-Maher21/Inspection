using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.SalesOrderCommandRepository
{
    public interface ISalesOrderLinesCommandRepository : ICommandRepository<SalesOrderLines>
    {
    }
}
