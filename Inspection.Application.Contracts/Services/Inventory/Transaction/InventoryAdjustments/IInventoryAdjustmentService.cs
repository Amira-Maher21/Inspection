using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryAdjustments
{
    public interface IInventoryAdjustmentService
    {
        Task<ReturnBase<InventoryAdjustmentDto>> Create(InventoryAdjustmentCreateDto createDto);
        Task<ReturnBase<InventoryAdjustmentDto>> Update(InventoryAdjustmentUpdateDto updateDto);
        Task<ReturnBase<InventoryAdjustmentDto>> Delete(long id);
        Task<ReturnBase<InventoryAdjustmentDto>> GetById(long id);
        //Task<ReturnBase<InventoryAdjustmentDto>> GetByInventoryAdjustmentNumber(string inventoryAdjustmentNumber);
        //Task<ReturnBase<List<InventoryAdjustmentDto>>> GetAll();
        Task<ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportInventoryAdjustments(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}