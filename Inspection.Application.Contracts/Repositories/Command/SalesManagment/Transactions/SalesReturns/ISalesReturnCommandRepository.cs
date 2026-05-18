using Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesReturns
{
    public interface ISalesReturnCommandRepository : ICommandRepository<SalesReturn>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteSalesReturnLinesBySalesReturnIds(List<long> salesReturnIds);

        Task<ReturnBase> DeleteSalesReturnAdjustmentsBySalesReturnIds(List<long> salesReturnIds);
    }
}