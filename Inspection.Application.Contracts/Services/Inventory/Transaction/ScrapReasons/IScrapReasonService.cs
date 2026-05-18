using Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.ScrapReasons
{
    public interface IScrapReasonService
    {
        Task<ReturnBase<ScrapReasonDto>> Create(ScrapReasonCreateDto createDto);

        Task<ReturnBase<ScrapReasonDto>> Update(ScrapReasonUpdateDto updateDto);

        Task<ReturnBase<ScrapReasonDto>> Delete(long id);

        Task<ReturnBase<ScrapReasonDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}