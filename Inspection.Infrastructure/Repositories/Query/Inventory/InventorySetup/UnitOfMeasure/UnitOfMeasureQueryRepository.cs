using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.UnitOfMeasures;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.UnitOfMeasure;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.UnitOfMeasure
{
    public class UnitOfMeasureQueryRepository : QueryRepositoryBase<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>, IUnitOfMeasureQueryRepository
    {
        public UnitOfMeasureQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>> GetAll()
        {
            var result = await _context.Set<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>().AsNoTracking().ToListAsync();
            return ReturnBase<List<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>.Success(result);
        }

        public async Task<Domain.Models.Inventory.InventorySetup.UnitOfMeasure?> GetById(long id)
        {
            return await _context.Set<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<Domain.Models.Inventory.InventorySetup.UnitOfMeasure>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var UnitOfMeasureRepository = new UnitOfMeasureQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await UnitOfMeasureRepository.Query(sqlQueryOptions);
        }


    }
}

