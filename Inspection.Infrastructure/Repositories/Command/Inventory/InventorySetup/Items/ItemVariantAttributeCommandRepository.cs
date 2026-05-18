using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Items
{
    internal class ItemVariantAttributeCommandRepository : CommandRepositoryBase<ItemVariantAttribute>, IItemVariantAttributeCommandRepository
    {
        public ItemVariantAttributeCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
        public async Task AddRange(List<ItemVariantAttribute> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
    }
}