using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Colors;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.Colors
{
    public interface IColorService
    {
        Task<ReturnBase<ColorDto>> Create(ColorCreateDto createDto);
        Task<ReturnBase<ColorDto>> Update(ColorUpdateDto updateDto);
        Task<ReturnBase<ColorDto>> Delete(long id);
        Task<ReturnBase<ColorDto>> GetById(long id);
        Task<ReturnBase<ColorDto>> GetByCode(string code);

        Task<ReturnBase<IEnumerable<ColorDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportColor(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}