using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.ItemAttributes
{
    public interface IItemAttributeService
    {
        Task<ReturnBase<ItemAttributeDto>> Create(ItemAttributeCreateDto createDto);
        Task<ReturnBase<ItemAttributeDto>> Update(ItemAttributeUpdateDto updateDto);
        Task<ReturnBase<ItemAttributeDto>> Delete(long id);
        Task<ReturnBase<ItemAttributeDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<ItemAttributeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
