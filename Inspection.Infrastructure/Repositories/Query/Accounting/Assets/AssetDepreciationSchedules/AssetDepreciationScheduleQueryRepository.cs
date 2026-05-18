using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Domain.Models.Accounting.Assets;
using Inspection.Domain.Models.Accounting.Assets.FixedAssets;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetDepreciationSchedules;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleQueryRepository : QueryRepositoryBase<AssetDepreciationSchedule>, IAssetDepreciationScheduleQueryRepository
    {
        public AssetDepreciationScheduleQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AssetDepreciationSchedule>>> GetAll()
        {
            var result = await _context.Set<AssetDepreciationSchedule>().AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetDepreciationSchedule>>.Success(result);
        }

        public async Task<AssetDepreciationSchedule?> GetById(long id)
        {
            return await _context.Set<AssetDepreciationSchedule>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var AssetDepreciationScheduleRepository = new AssetDepreciationScheduleQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await AssetDepreciationScheduleRepository.Query(sqlQueryOptions);
        }


    }
}

