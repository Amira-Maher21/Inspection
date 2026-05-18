using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryScraps;
using Inspection.Domain.Models.Inventory.Transaction.InventoryScraps;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapCommandRepository
        : CommandRepositoryBase<InventoryScrap>, IInventoryScrapCommandRepository
    {
        public InventoryScrapCommandRepository(
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

        public async Task<ReturnBase> DeleteById(long id)
        {
            var entity = await _dbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inventory Scrap Not Found"
                    }
                });
            }

            _dbSet.Remove(entity);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteInventoryScrapLineByIds(List<long> ids)
        {
            var lines = await _context.Set<InventoryScrapLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<InventoryScrapLine>().RemoveRange(lines);

            return ReturnBase.Success();
        }
    }
}