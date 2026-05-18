using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Colors;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Colors;
using Inspection.Domain.Models.Inventory.InventorySetup.Colors;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Colors;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Colors
{
    public class ColorQueryRepository : QueryRepositoryBase<Color>, IColorQueryRepository
    {
        public ColorQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<Color?> GetById(long id)
        {
            return await _context.Set<Color>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Color?> GetByCode(string code)
        {
            return await _context.Set<Color>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<ColorDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CurrencyQueryRepository = new ColorQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CurrencyQueryRepository.Query(sqlQueryOptions);
        }
    }

}
