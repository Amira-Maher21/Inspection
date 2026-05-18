using Inspection.Application.Contracts.Dto.Inventory.InventorySetup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup
{
    public interface IWarehouseService
    {
        Task<ReturnBase<WarehouseDto>> Create(WarehouseCreateDto createDto);
        Task<ReturnBase<WarehouseDto>> Update(WarehouseUpdateDto updateDto);
        Task<ReturnBase<WarehouseDto>> Delete(long id);
        Task<ReturnBase<WarehouseDto>> GetById(long id);
        Task<ReturnBase<List<WarehouseDto>>> GetAll();
        Task<ReturnBase<IEnumerable<WarehouseReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<IEnumerable<WarehouseSelectDto>>> Select(SqlQueryOptions sqlQueryOptions);
    }
}
