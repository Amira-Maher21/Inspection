using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.ItemGroups
{

    public interface IItemGroupService
    {
        Task<ReturnBase<ItemGroupDto>> Create(ItemGroupCreateDto createDto);
        Task<ReturnBase<ItemGroupDto>> Update(ItemGroupUpdateDto updateDto);
        Task<ReturnBase<ItemGroupDto>> Delete(long id);
        Task<ReturnBase<ItemGroupDto>> GetById(long id);
        Task<ReturnBase<List<ItemGroupDto>>> GetAll();
        Task<ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
