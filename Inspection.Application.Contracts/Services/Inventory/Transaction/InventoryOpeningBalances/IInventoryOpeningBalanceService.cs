using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryOpeningBalances
{
    public interface IInventoryOpeningBalanceService
    {
        Task<ReturnBase<InventoryOpeningBalanceDto>> Create(InventoryOpeningBalanceCreateDto createDto);
        Task<ReturnBase<InventoryOpeningBalanceDto>> Update(InventoryOpeningBalanceUpdateDto updateDto);
        Task<ReturnBase<InventoryOpeningBalanceDto>> Delete(long id);
        Task<ReturnBase<InventoryOpeningBalanceDto>> GetById(long id);
        //Task<ReturnBase<List<InventoryOpeningBalanceDto>>> GetAll();
        Task<ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportInventoryOpeningBalances(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}