using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEvents;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.AssetAccountingEvents
{
    public interface IAssetAccountingEventService
    {
        Task<ReturnBase<AssetAccountingEventDto>> Create(AssetAccountingEventCreateDto createDto);
        Task<ReturnBase<AssetAccountingEventDto>> Update(AssetAccountingEventUpdateDto updateDto);
        Task<ReturnBase<AssetAccountingEventDto>> Delete(long id);
        Task<ReturnBase<AssetAccountingEventDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetAccountingEventDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
