using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetAccountingEvents;
using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetAccountingEvents;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetAccountingEvents
{
    public class AssetAccountingEventQueryRepository : QueryRepositoryBase<AssetAccountingEvent>, IAssetAccountingEventQueryRepository
    {
        public AssetAccountingEventQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AssetAccountingEvent>>> GetAll()
        {
            var result = await _context.Set<AssetAccountingEvent>().AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetAccountingEvent>>.Success(result);
        }

        public async Task<AssetAccountingEvent?> GetById(long id)
        {
            return await _context.Set<AssetAccountingEvent>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<AssetAccountingEvent>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var AssetAccountingEventRepository = new AssetAccountingEventQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await AssetAccountingEventRepository.Query(sqlQueryOptions);
        }


    }
}

