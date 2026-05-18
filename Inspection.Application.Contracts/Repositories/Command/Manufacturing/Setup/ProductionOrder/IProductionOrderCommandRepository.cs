using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Manufacturing.Setup.ProductionOrders
{
    public interface IProductionOrderCommandRepository : ICommandRepository<ProductionOrder>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteProductionOrderLinesByProductionOrderIds(List<long> ids);
    }
}