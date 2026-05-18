using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.Transactions.SalesReturns
{
    public interface ISalesReturnService
    {
        Task<ReturnBase<SalesReturnDto>> Create(SalesReturnCreateDto createDto);

        Task<ReturnBase<SalesReturnDto>> Update(SalesReturnUpdateDto updateDto);

        Task<ReturnBase<SalesReturnDto>> Delete(long id);

        Task<ReturnBase<SalesReturnDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<SalesReturnReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}