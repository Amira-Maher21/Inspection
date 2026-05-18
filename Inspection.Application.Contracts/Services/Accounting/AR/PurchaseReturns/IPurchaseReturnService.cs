using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AR.PurchaseReturns
{
    public interface IPurchaseReturnService
    {
        Task<ReturnBase<PurchaseReturnDto>> Create(PurchaseReturnCreateDto createDto);
        Task<ReturnBase<PurchaseReturnDto>> Update(PurchaseReturnUpdateDto updateDto);
        Task<ReturnBase<PurchaseReturnDto>> Delete(long id);
        Task<ReturnBase<PurchaseReturnDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
