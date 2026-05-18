using Inspection.Domain.Models.Accounting.AR.MasterData;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AR.MasterData
{
    public interface ICustomerQueryRepository : IQueryRepository<Customer>
    {
        Task<Customer?> GetById(long id);
        Task<ReturnBase<IEnumerable<CustomerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<Customer?> GetByCode(string code);




    }
}
