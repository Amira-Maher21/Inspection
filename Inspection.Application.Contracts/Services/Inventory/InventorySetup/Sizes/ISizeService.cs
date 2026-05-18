using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.Sizes
{
    public interface ISizeService
    {
        Task<ReturnBase<SizeDto>> Create(SizeCreateDto createDto);
        Task<ReturnBase<SizeDto>> Update(SizeUpdateDto updateDto);
        Task<ReturnBase<SizeDto>> Delete(long id);
        Task<ReturnBase<SizeDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<SizeDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportSize(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
