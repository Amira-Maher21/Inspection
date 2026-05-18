using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesReturns
{
    public interface ISalesReturnQueryRepository : IQueryRepository<SalesReturn>
    {
        Task<ReturnBase<List<SalesReturn>>> GetAll();

        Task<SalesReturn?> GetById(long id);

        Task<ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}