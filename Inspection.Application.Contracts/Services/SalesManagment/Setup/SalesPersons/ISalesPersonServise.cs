using Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.Setup.SalesPersons
{
    public interface ISalesPersonServise
    {



        Task<ReturnBase<SalesPersonDto>> Create(SalesPersonCreateDto dto);
        Task<ReturnBase<SalesPersonDto>> Update(SalesPersonUpdateDto dto);
        Task<ReturnBase<SalesPersonDto>> Delete(long id);

        Task<ReturnBase<SalesPersonDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<SalesPersonSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
