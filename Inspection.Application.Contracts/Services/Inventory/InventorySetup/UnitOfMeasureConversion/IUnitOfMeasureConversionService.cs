using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.UnitOfMeasureConversionConversion
{
    public interface IUnitOfMeasureConversionService
    {
        Task<ReturnBase<UnitOfMeasureConversionDto>> Create(UnitOfMeasureConversionCreateDto createDto);
        Task<ReturnBase<UnitOfMeasureConversionDto>> Update(UnitOfMeasureConversionUpdateDto updateDto);
        Task<ReturnBase<UnitOfMeasureConversionDto>> Delete(long id);
        Task<ReturnBase<UnitOfMeasureConversionDto>> GetById(long id);
        Task<ReturnBase<List<UnitOfMeasureConversionDto>>> GetAll();
        Task<ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportUnitOfMeasureConversion(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
