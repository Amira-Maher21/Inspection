using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Domain.Models.Inventory.System;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryCostLayers
{
    public interface IInventoryCostLayerQueryRepository : IQueryRepository<InventoryCostLayer>
    {
        Task<InventoryCostLayer?> GetById(long id);
        Task<InventoryCostLayer?> GetByKey(long itemId, long warehouseId);
        Task<ReturnBase<IEnumerable<InventoryCostLayerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}