using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetLocations;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetLocations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetLocations
{
    public class AssetLocationQueryRepository : QueryRepositoryBase<AssetLocation>, IAssetLocationQueryRepository
    {
        public AssetLocationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<AssetLocation?> GetByCode(string code)
        {
            return await _context.Set<AssetLocation>()
                .Where(x => x.LocationCode == code)
                .FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<List<AssetLocation>>> GetAll()
        {
            var result = await _context.Set<AssetLocation>()
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetLocation>>.Success(result);
        }

        public async Task<AssetLocation?> GetById(long id)
        {
            return await _context.Set<AssetLocation>().FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var assetLocationRepository = new AssetLocationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await assetLocationRepository.Query(sqlQueryOptions);
        }
    }

}