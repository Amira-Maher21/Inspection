using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.UnitOfMeasureConversions;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public class UnitOfMeasureConversionQueryRepository : QueryRepositoryBase<UnitOfMeasureConversion>, IUnitOfMeasureConversionQueryRepository
    {
        public UnitOfMeasureConversionQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<UnitOfMeasureConversion>>> GetAll()
        {
            var result = await _context.Set<UnitOfMeasureConversion>().AsNoTracking().ToListAsync();
            return ReturnBase<List<UnitOfMeasureConversion>>.Success(result);
        }

        public async Task<UnitOfMeasureConversion?> GetById(long id)
        {
            return await _context.Set<UnitOfMeasureConversion>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var UnitOfMeasureConversionRepository = new UnitOfMeasureConversionQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await UnitOfMeasureConversionRepository.Query(sqlQueryOptions);
        }


    }
}

