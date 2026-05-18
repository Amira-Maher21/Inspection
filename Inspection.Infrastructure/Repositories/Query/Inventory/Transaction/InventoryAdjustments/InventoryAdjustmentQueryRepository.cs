using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryAdjustments;
using Inspection.Domain.Models.Inventory.Transaction.InventoryAdjustments;
using Inspection.Infrastructure.QueryObjects.Inventory.Transaction.InventoryAdjustments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.InventoryAdjustments
{
    public class InventoryAdjustmentQueryRepository : QueryRepositoryBase<InventoryAdjustment>, IInventoryAdjustmentQueryRepository
    {
        public InventoryAdjustmentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<InventoryAdjustment>>> GetAll()
        {
            var result = await _context.Set<InventoryAdjustment>()
                .Include(x => x.InventoryAdjustmentLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<InventoryAdjustment>>.Success(result);
        }

        public async Task<InventoryAdjustment?> GetById(long id)
        {
            return await _context.Set<InventoryAdjustment>()
                .Include(x => x.InventoryAdjustmentLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<InventoryAdjustment?> GetByInventoryAdjustmentNumber(string inventoryAdjustmentNumber)
        {
            return await _context.Set<InventoryAdjustment>()
                .Include(x => x.InventoryAdjustmentLines)
                .FirstOrDefaultAsync(x => x.InventoryAdjustmentNumber == inventoryAdjustmentNumber);
        }

        public async Task<ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var inventoryAdjustmentRepository = new InventoryAdjustmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await inventoryAdjustmentRepository.Query(sqlQueryOptions);
        }
    }
}