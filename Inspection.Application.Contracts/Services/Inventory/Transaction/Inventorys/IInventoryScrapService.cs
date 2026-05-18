using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryScraps;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryScraps
{
    public interface IInventoryScrapService
    {
        Task<ReturnBase<InventoryScrapDto>> Create(InventoryScrapCreateDto dto);
        Task<ReturnBase<InventoryScrapDto>> Update(InventoryScrapUpdateDto dto);
        Task<ReturnBase<InventoryScrapDto>> Delete(long id);
        Task<ReturnBase<InventoryScrapDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<InventoryScrapReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}