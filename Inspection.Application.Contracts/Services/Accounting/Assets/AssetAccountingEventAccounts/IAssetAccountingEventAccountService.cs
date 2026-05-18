using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEvents;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.AssetAccountingEventAccounts
{
    public interface IAssetAccountingEventAccountService
    {
        Task<ReturnBase<AssetAccountingEventAccountDto>> Create(AssetAccountingEventAccountCreateDto createDto);
        Task<ReturnBase<AssetAccountingEventAccountDto>> Update(AssetAccountingEventAccountUpdateDto updateDto);
        Task<ReturnBase<AssetAccountingEventAccountDto>> Delete(long id);
        Task<ReturnBase<AssetAccountingEventAccountDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetAccountingEventDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
