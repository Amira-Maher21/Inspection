using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.FixedAssets;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using Inspection.Infrastructure.QueryObjects.Accounting.Assets.Setup.FixedAssets;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.FixedAssets
{
    public class FixedAssetQueryRepository : QueryRepositoryBase<FixedAsset>, IFixedAssetQueryRepository
    {
        public FixedAssetQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<FixedAsset?> GetById(long id)
        {
            return await _context.Set<FixedAsset>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<FixedAsset?> GetByCode(string code)
        {
            return await _context.Set<FixedAsset>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
        public async Task<ReturnBase<List<FixedAsset>>> GetAll()
        {
            var result = await _context.Set<FixedAsset>().AsNoTracking().ToListAsync();
            return ReturnBase<List<FixedAsset>>.Success(result);
        }

        public async Task<ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var fixedAssetRepository = new FixedAssetQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await fixedAssetRepository.Query(sqlQueryOptions);
        }
    }
}