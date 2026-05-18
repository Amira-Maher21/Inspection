using Inspection.Application.Contracts.Repositories.Command.Manufacturing.Setup.ProductionOrders;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Manufacturing.Setup.ProductionOrders
{
    public class ProductionOrderCommandRepository : CommandRepositoryBase<ProductionOrder>, IProductionOrderCommandRepository
    {
        public ProductionOrderCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
        public async Task<ReturnBase> DeleteById(long id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = $"Production Order with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteProductionOrderLinesByProductionOrderIds(List<long> ids)
        {
            var productionOrderLines = await _context.Set<ProductionOrderLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<ProductionOrderLine>().RemoveRange(productionOrderLines);
            return ReturnBase.Success();
        }
    }
}