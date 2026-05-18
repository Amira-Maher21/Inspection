using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Models;
using Inspection.Domain.Models.Inventory.InventorySetup.Models;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Models;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Models
{
    public class ModelQueryRepository : QueryRepositoryBase<Model>, IModelQueryRepository
    {
        public ModelQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Model>>> GetAll()
        {
            var result = await _context.Set<Model>().AsNoTracking().ToListAsync();
            return ReturnBase<List<Model>>.Success(result);
        }

        public async Task<Model?> GetByCode(string code)
        {
            return await _context.Set<Model>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<Model?> GetById(long id)
        {
            return await _context.Set<Model>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<ModelSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var ModelRepository = new ModelQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await ModelRepository.Query(sqlQueryOptions);
        }


    }
}



