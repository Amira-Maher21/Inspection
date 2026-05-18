using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Brands;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.Brands
{
    public interface IBrandService
    {
        Task<ReturnBase<BrandDto>> Create(BrandCreateDto createDto);
        Task<ReturnBase<BrandDto>> Update(BrandUpdateDto updateDto);
        Task<ReturnBase<BrandDto>> Delete(long id);
        Task<ReturnBase<BrandDto>> GetById(long id);
        Task<ReturnBase<List<BrandDto>>> GetAll();
        Task<ReturnBase<IEnumerable<BrandDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportBrand(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
