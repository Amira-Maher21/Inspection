using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.AssetDepreciationSchedules
{
    public interface IAssetDepreciationScheduleService
    {
        Task<ReturnBase<AssetDepreciationScheduleDto>> Create(AssetDepreciationScheduleCreateDto createDto);
        Task<ReturnBase<AssetDepreciationScheduleDto>> Update(AssetDepreciationScheduleUpdateDto updateDto);
        Task<ReturnBase<AssetDepreciationScheduleDto>> Delete(long id);
        Task<ReturnBase<AssetDepreciationScheduleDto>> GetById(long id);
        Task<ReturnBase<List<AssetDepreciationScheduleDto>>> GetAll();
        Task<ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportAssetDepreciationSchedule(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
