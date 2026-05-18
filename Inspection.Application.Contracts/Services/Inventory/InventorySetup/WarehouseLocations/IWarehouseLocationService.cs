using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.WarehouseLocations
{
    public interface IWarehouseLocationService
    {
        Task<ReturnBase<WarehouseLocationDto>> Create(WarehouseLocationCreateDto createDto);
        Task<ReturnBase<WarehouseLocationDto>> Update(WarehouseLocationUpdateDto updateDto, long id);
        Task<ReturnBase<WarehouseLocationDto>> Delete(long id);
        Task<ReturnBase<WarehouseLocationDto>> GetById(long id);
        Task<ReturnBase<WarehouseLocationDto>> GetByCode(String code);
        Task<ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<WarehouseLocationSelectDto>>> Select(SqlQueryOptions sqlQueryOptions);
        Task<List<WarehouseLocationDto>> GetAll();



    }
}
