using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.ItemAttributes;
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.ItemAttributes
{
    public class ItemAttributeCommandRepository : CommandRepositoryBase<ItemAttribute>, IItemAttributeCommandRepository
    {
        public ItemAttributeCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Item Attribute with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteItemAttributeValuesByItemAttributeId(long itemAttributeId)
        {
            var itemAttributeValues = await _context.Set<ItemAttributeValue>()
                .Where(v => v.ItemAttributeId == itemAttributeId)
                .ToListAsync();

            if (!itemAttributeValues.Any())
                return ReturnBase.Success();

            _context.Set<ItemAttributeValue>().RemoveRange(itemAttributeValues);

            return ReturnBase.Success();
        }
        public async Task<ReturnBase> DeleteItemAttributeValuesByItemAttributeIds(List<long> ids)
        {
            var itemAttributeValues = await _context.Set<ItemAttributeValue>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<ItemAttributeValue>().RemoveRange(itemAttributeValues);

            return ReturnBase.Success();
        }
    }
}