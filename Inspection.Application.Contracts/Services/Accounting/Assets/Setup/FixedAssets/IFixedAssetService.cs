using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.Setup.FixedAssets
{
    public interface IFixedAssetService
    {
        Task<ReturnBase<FixedAssetDto>> Create(FixedAssetCreateDto createDto);
        Task<ReturnBase<FixedAssetDto>> Update(FixedAssetUpdateDto updateDto);
        Task<ReturnBase<FixedAssetDto>> Delete(long id);
        Task<ReturnBase<FixedAssetDto>> GetById(long id);
        Task<ReturnBase<FixedAssetDto>> GetByCode(string code);
        //Task<ReturnBase<List<FixedAssetDto>>> GetAll();
        Task<ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportFixedAssets(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}