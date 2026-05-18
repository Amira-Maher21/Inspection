using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetCustodies;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetCustodies
{
    internal class AssetCustodyQueryRepository : QueryRepositoryBase<AssetCustody>, IAssetCustodyQueryRepository
    {
        public AssetCustodyQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AssetCustody>>> GetAll()
        {
            var result = await _context.Set<AssetCustody>()
                .Include(x => x.AssetCustodyLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetCustody>>.Success(result);
        }

        public async Task<AssetCustody?> GetById(long id)
        {
            return await _context.Set<AssetCustody>()
                .Include(x => x.AssetCustodyLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {

            var assetCustodyRepository = new AssetCustodyQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await assetCustodyRepository.Query(sqlQueryOptions);
        }
    }

}
