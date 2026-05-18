using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetCustodies
{
    public interface IAssetCustodyService
    {
        Task<ReturnBase<AssetCustodyDto>> Create(AssetCustodyCreateDto createDto);
        Task<ReturnBase<AssetCustodyDto>> Update(AssetCustodyUpdateDto updateDto);
        Task<ReturnBase<AssetCustodyDto>> Delete(long id);
        Task<ReturnBase<AssetCustodyDto>> GetById(long id);
        //Task<ReturnBase<List<AssetCustodyDto>>> GetAll();
        Task<ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
