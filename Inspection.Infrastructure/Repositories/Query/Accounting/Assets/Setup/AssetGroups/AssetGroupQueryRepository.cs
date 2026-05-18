using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetGroups;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetGroupQueries;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetGroups
{
    public class AssetGroupQueryRepository : QueryRepositoryBase<AssetGroup>, IAssetGroupQueryRepository
    {
        public AssetGroupQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AssetGroup>>> GetAll()
        {
            var result = await _context.Set<AssetGroup>()
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetGroup>>.Success(result);
        }

        public async Task<AssetGroup?> GetById(long id)
        {
            return await _context.Set<AssetGroup>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var AssetGroupRepository = new AssetGroupQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await AssetGroupRepository.Query(sqlQueryOptions);
        }
    }

}
