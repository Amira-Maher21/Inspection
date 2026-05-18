using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Batchs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Batchs
{
    public interface IBatchServise
    {
        Task<ReturnBase<BatchDto>> Create(BatchCreateDto dto);
        Task<ReturnBase<BatchDto>> Update(BatchUpdateDto dto);
        Task<ReturnBase<BatchDto>> Delete(long id);

        Task<ReturnBase<BatchDto>> GetById(long id);
        //Task<ReturnBase<IEnumerable<BatchDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null);

        Task<ReturnBase<IEnumerable<BatchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
