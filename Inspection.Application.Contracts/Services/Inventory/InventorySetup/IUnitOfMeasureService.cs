using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasure;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup
{
    public interface IUnitOfMeasureService
    {
        Task<ReturnBase<UnitOfMeasureDto>> Create(UnitOfMeasureCreateDto createDto);
        Task<ReturnBase<UnitOfMeasureDto>> Update(UnitOfMeasureUpdateDto updateDto);
        Task<ReturnBase<UnitOfMeasureDto>> Delete(long id);
        Task<ReturnBase<UnitOfMeasureDto>> GetById(long id);
        Task<ReturnBase<List<UnitOfMeasureDto>>> GetAll();
        Task<ReturnBase<IEnumerable<UnitOfMeasureDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportUnitOfMeasure(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
