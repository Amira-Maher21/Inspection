using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Domain.Models.Inventory.System.InventoryBalances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.System.InventoryBalances
{
    public interface IInventoryBalanceService
    {
        Task<ReturnBase<InventoryBalanceDto>> Create(InventoryBalanceCreateDto createDto);
        Task<ReturnBase<InventoryBalanceDto>> Update(InventoryBalanceUpdateDto updateDto);
        Task<ReturnBase<InventoryBalanceDto>> Delete(long id);
        Task<ReturnBase<InventoryBalanceDto>> GetById(long id);
        Task<ReturnBase<List<InventoryBalanceDto>>> GetAll();
        Task<InventoryBalance?> GetByKey(long itemId, long warehouseId, long? locationId);
        Task<ReturnBase<IEnumerable<InventoryBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
