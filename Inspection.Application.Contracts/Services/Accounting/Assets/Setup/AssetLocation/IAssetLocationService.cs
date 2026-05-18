using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetLocations
{
    public interface IAssetLocationService
    {
        Task<ReturnBase<AssetLocationDto>> Create(AssetLocationCreateDto createDto);
        Task<ReturnBase<AssetLocationDto>> Update(AssetLocationUpdateDto updateDto);
        Task<ReturnBase<AssetLocationDto>> Delete(long id);
        Task<ReturnBase<AssetLocationDto>> GetById(long id);
        Task<ReturnBase<AssetLocationDto>> GetByCode(string code);
        Task<ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<ImportResultDto>> ImportAssetLocation(ExcelImportRequestDto dto);
        //Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}