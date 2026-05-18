using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Manufacturing.Setup.ProductionOrders
{
    public interface IProductionOrderService
    {
        Task<ReturnBase<ProductionOrderDto>> Create(ProductionOrderCreateDto createDto);
        Task<ReturnBase<ProductionOrderDto>> Update(ProductionOrderUpdateDto updateDto);
        Task<ReturnBase<ProductionOrderDto>> Delete(long id);
        Task<ReturnBase<ProductionOrderDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}