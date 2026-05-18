using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetCategoryQueries;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetCategories
{
    public class AssetCategoryQueryRepository : QueryRepositoryBase<AssetCategory>, IAssetCategoryQueryRepository
    {
        public AssetCategoryQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<AssetCategory?> GetByCode(string code)
        {
            return await _context.Set<AssetCategory>()
                .Where(x => x.CategoryCode == code)
                .FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<List<AssetCategory>>> GetAll()
        {
            var result = await _context.Set<AssetCategory>()
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetCategory>>.Success(result);
        }

        public async Task<AssetCategory?> GetById(long id)
        {
            return await _context.Set<AssetCategory>().FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var assetCategoryRepository = new AssetCategoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await assetCategoryRepository.Query(sqlQueryOptions);
        }
    }

}