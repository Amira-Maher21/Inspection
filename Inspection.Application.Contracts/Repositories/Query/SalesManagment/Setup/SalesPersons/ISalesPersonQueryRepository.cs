using Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.Setup.SalesPersons
{
    public interface ISalesPersonQueryRepository
    {
        Task<SalesPerson?> GetById(long id);

        Task<ReturnBase<IEnumerable<SalesPersonSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<SalesPerson?> GetByCode(string code);
    }
}
