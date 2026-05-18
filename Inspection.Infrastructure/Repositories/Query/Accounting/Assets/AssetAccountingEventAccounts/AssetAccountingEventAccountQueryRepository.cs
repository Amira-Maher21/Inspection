using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetAccountingEventAccounts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetAccountingEventAccounts
{
    public class AssetAccountingEventAccountQueryRepository : QueryRepositoryBase<AssetAccountingEventAccount>, IAssetAccountingEventAccountQueryRepository
    {
        public AssetAccountingEventAccountQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AssetAccountingEventAccount>>> GetAll()
        {
            var result = await _context.Set<AssetAccountingEventAccount>().AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetAccountingEventAccount>>.Success(result);
        }

        public async Task<AssetAccountingEventAccount?> GetById(long id)
        {
            return await _context.Set<AssetAccountingEventAccount>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<AssetAccountingEventAccount>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var AssetAccountingEventRepository = new AssetAccountingEventAccountQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await AssetAccountingEventRepository.Query(sqlQueryOptions);
        }


    }
}

