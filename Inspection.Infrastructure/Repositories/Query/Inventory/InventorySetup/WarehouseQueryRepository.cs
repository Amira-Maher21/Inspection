using Inspection.Application.Contracts.Dto.Inventory.InventorySetup;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup
{
    public class WarehouseQueryRepository : QueryRepositoryBase<Warehouse>, IWarehouseQueryRepository
    {
        public WarehouseQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Warehouse>>> GetAll()
        {
            var result = await _context.Set<Warehouse>().AsNoTracking().ToListAsync();
            return ReturnBase<List<Warehouse>>.Success(result);
        }

        public async Task<Warehouse?> GetById(long id)
        {
            return await _context.Set<Warehouse>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<WarehouseReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var WarehouseRepository = new WarehouseQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await WarehouseRepository.Query(sqlQueryOptions);
        }


        public async Task<ReturnBase<IEnumerable<WarehouseSelectDto>>> Select(SqlQueryOptions sqlQueryOptions)
        {
            var warehouseSelectQuery = new WarehouseSelectQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await warehouseSelectQuery.Query(sqlQueryOptions);
        }


        public async Task<Warehouse?> GetByCode(string code)
        {
            return await _context.Set<Warehouse>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}

