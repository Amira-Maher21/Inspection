using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.Models
{
    public interface IModelService
    {
        Task<ReturnBase<ModelDto>> Create(ModelCreateDto createDto);
        Task<ReturnBase<ModelDto>> Update(ModelUpdateDto updateDto);
        Task<ReturnBase<ModelDto>> Delete(long id);
        Task<ReturnBase<ModelDto>> GetById(long id);
        Task<ReturnBase<List<ModelDto>>> GetAll();
        Task<ReturnBase<IEnumerable<ModelSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportModel(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
