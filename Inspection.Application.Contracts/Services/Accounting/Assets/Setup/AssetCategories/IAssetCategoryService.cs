using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetCategories
{
    public interface IAssetCategoryService
    {
        Task<ReturnBase<AssetCategoryDto>> Create(AssetCategoryCreateDto createDto);
        Task<ReturnBase<AssetCategoryDto>> Update(AssetCategoryUpdateDto updateDto);
        Task<ReturnBase<AssetCategoryDto>> Delete(long id);
        Task<ReturnBase<AssetCategoryDto>> GetById(long id);
        Task<ReturnBase<AssetCategoryDto>> GetByCode(string code);
        Task<ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<ImportResultDto>> ImportAssetCategory(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}