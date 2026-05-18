using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Domain.Enums.InventoryEnums.Items;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.InventorySetup.Items
{
    public interface IItemService
    {
        Task<ReturnBase<ItemDto>> Create(ItemCreateDto createDto);
        Task<ReturnBase<ItemDto>> Update(ItemUpdateDto updateDto);
        Task<ReturnBase<ItemDto>> Delete(long id);
        Task<ReturnBase<ItemDto>> GetById(long id);
        //Task<ReturnBase<List<ItemDto>>> GetAll();
        Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> FilteredSearch(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<bool>> CreateVariants(ItemVariantAttributeCreateDto dto);
        Task<ReturnBase<List<ItemVariantAttributeDto>>> GetVariants(long itemId);

        //Task<ReturnBase<ImportResultDto>> ImportItems(ExcelImportRequestDto dto);
        //Task<ReturnBase<FileResultDto>> DownloadTemplate();

        Task<ReturnBase<ItemForecastResultDto>> GetItemForecastReorderQuantity(long itemId, ItemForecastPeriod period);
    }
}