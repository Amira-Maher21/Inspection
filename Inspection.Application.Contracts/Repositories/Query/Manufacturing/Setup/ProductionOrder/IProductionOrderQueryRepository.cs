using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Manufacturing.Setup.ProductionOrders
{
    public interface IProductionOrderQueryRepository : IQueryRepository<ProductionOrder>
    {
        Task<ReturnBase<List<ProductionOrder>>> GetAll();
        Task<ProductionOrder?> GetById(long id);
        Task<ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}