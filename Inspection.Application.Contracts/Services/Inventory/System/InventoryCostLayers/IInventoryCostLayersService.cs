using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Domain.Models.Inventory.System;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.System.InventoryCostLayers
{
    public interface IInventoryCostLayersService
    {
        Task<ReturnBase<InventoryCostLayerDto>> Create(InventoryCostLayerCreateDto createDto);
        Task<ReturnBase<InventoryCostLayerDto>> Update(InventoryCostLayerUpdateDto updateDto);
        Task<ReturnBase<InventoryCostLayerDto>> Delete(long id);
        Task<ReturnBase<InventoryCostLayerDto>> GetById(long id);
        Task<InventoryCostLayer?> GetByKey(long itemId, long warehouseId);

        Task<ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}