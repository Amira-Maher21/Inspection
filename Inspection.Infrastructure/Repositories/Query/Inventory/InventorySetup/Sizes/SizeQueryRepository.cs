using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Sizes;
using Inspection.Domain.Models.Inventory.InventorySetup.Sizes;
using Inspection.Infrastructure.QueryObjects.Inventory.Sizs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Sizes
{

    public class SizeQueryRepository : QueryRepositoryBase<Size>, ISizeQueryRepository
    {
        public SizeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<Size?> GetById(long id)
        {
            return await _context.Set<Size>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Size?> GetByCode(string code)
        {
            return await _context.Set<Size>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<SizeDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CurrencyQueryRepository = new SizeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CurrencyQueryRepository.Query(sqlQueryOptions);
        }
    }

}
