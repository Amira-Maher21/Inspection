using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;
using Inspection.Infrastructure.QueryObjects.Inventory.InventoryOpeningBalances;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.InventoryOpeningBalances
{

    public class InventoryOpeningBalanceQueryRepository : QueryRepositoryBase<InventoryOpeningBalance>, IInventoryOpeningBalanceQueryRepository
    {
        public InventoryOpeningBalanceQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<ReturnBase<List<InventoryOpeningBalance>>> GetAll()
        {
            var result = await _context.Set<InventoryOpeningBalance>()
                .Include(x => x.InventoryOpeningBalanceLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<InventoryOpeningBalance>>.Success(result);
        }

        public async Task<InventoryOpeningBalance?> GetById(long id)
        {
            return await _context.Set<InventoryOpeningBalance>()
                .Include(x => x.InventoryOpeningBalanceLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var inventoryOpeningBalanceRepository = new InventoryOpeningBalanceQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await inventoryOpeningBalanceRepository.Query(sqlQueryOptions);
        }
    }
}