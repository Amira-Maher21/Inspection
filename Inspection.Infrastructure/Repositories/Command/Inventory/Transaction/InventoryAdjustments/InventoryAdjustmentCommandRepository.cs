using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryAdjustments;
using Inspection.Domain.Models.Inventory.Transaction.InventoryAdjustments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.InventoryAdjustments
{
    public class InventoryAdjustmentCommandRepository : CommandRepositoryBase<InventoryAdjustment>, IInventoryAdjustmentCommandRepository
    {
        public InventoryAdjustmentCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Inventory Adjustment with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteInventoryAdjustmentLinesByIds(List<long> ids)
        {
            var inventoryAdjustmentLine = await _context.Set<InventoryAdjustmentLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<InventoryAdjustmentLine>().RemoveRange(inventoryAdjustmentLine);

            return ReturnBase.Success();
        }
    }
}