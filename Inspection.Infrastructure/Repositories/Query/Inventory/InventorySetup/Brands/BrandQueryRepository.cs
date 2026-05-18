using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Brands;
using Inspection.Domain.Models.Inventory.InventorySetup.Brands;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Brands;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Brands
{
    public class BrandQueryRepository : QueryRepositoryBase<Brand>, IBrandQueryRepository
    {
        public BrandQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Brand>>> GetAll()
        {
            var result = await _context.Set<Brand>().AsNoTracking().ToListAsync();
            return ReturnBase<List<Brand>>.Success(result);
        }

        public async Task<Brand?> GetById(long id)
        {
            return await _context.Set<Brand>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Brand?> GetByCode(string code)
        {
            return await _context.Set<Brand>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<Brand>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var BrandRepository = new BrandQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await BrandRepository.Query(sqlQueryOptions);
        }


    }
}

