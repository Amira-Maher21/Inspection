using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetTransactions;
using Inspection.Domain.Models.Accounting.Assets.AssetTransactions;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.AssetTransactions;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetTransactions
{
    public class AssetTransactionQueryRepository : QueryRepositoryBase<AssetTransaction>, IAssetTransactionQueryRepository
    {
        public AssetTransactionQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<AssetTransaction?> GetById(long id)
        {
            return await _context.Set<AssetTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var AssetTransactionQueryRepo = new AssetTransactionQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await AssetTransactionQueryRepo.Query(sqlQueryOptions);
        }
    }

}
