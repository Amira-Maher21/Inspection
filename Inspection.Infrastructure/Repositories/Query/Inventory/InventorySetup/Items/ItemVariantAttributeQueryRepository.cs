using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Items
{
    public class ItemVariantAttributeQueryRepository : QueryRepositoryBase<ItemVariantAttribute>, IItemVariantAttributeQueryRepository
    {
        public ItemVariantAttributeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<List<ItemVariantGroupDto>> GetByParentItemId(long parentItemId)
        {
            var result = await _context.Set<ItemVariantAttribute>()
                .Where(x => x.Item.RelatedItemVariantId == parentItemId)
                .GroupBy(x => x.ItemId)
                .Select(g => new ItemVariantGroupDto
                {
                    ItemId = g.Key,
                    AttributeValueIds = g.Select(x => x.ItemAttributeValueId).ToList()
                })
                .ToListAsync();

            return result;
        }
        public async Task<List<ItemVariantAttributeDto>> GetVariants(long itemId)
        {
            var variants = await _context.Set<Item>()
                .Where(x => x.RelatedItemVariantId == itemId)
                .Select(x => new ItemVariantAttributeDto
                {
                    //Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    SKU = x.SKU,
                    //ItemGroup = x.ItemGroup.Name,
                    UnitPrice = x.UnitPrice,

                    AttributeValueIds = _context.Set<ItemVariantAttribute>()
                        .Where(v => v.ItemId == x.Id)
                        .Select(v => v.ItemAttributeValueId)
                        .ToList()
                })
                .ToListAsync();

            return variants;
        }

    }
}