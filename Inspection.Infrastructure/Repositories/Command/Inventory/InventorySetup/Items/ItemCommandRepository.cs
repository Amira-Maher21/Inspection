using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Items
{
    public class ItemCommandRepository : CommandRepositoryBase<Item>, IItemCommandRepository
    {
        public ItemCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = " Item Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteItemReordersByItemId(long itemId)
        {
            var itemReorders = await _context.Set<ItemReorderPerWarehouse>()
                .Where(v => v.ItemId == itemId)
                .ToListAsync();

            if (!itemReorders.Any())
                return ReturnBase.Success();

            _context.Set<ItemReorderPerWarehouse>().RemoveRange(itemReorders);

            return ReturnBase.Success();
        }
        public async Task<ReturnBase> DeleteItemReordersByIds(List<long> ids)
        {
            var itemReorders = await _context.Set<ItemReorderPerWarehouse>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<ItemReorderPerWarehouse>().RemoveRange(itemReorders);

            return ReturnBase.Success();
        }
    }
}