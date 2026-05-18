using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetMaintenances;
using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;
using Inspection.Infrastructure.QueryObjects.Accounting.Assets.AssetMaintenances;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetMaintenances
{
    public class AssetMaintenanceQueryRepository : QueryRepositoryBase<AssetMaintenance>, IAssetMaintenanceQueryRepository
    {
        public AssetMaintenanceQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AssetMaintenance>>> GetAll()
        {
            var result = await _context.Set<AssetMaintenance>()
                .Include(x => x.AssetMaintenanceLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<AssetMaintenance>>.Success(result);
        }

        public async Task<AssetMaintenance?> GetById(long id)
        {
            return await _context.Set<AssetMaintenance>()
                .Include(x => x.AssetMaintenanceLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var assetMaintenanceRepository = new AssetMaintenanceQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await assetMaintenanceRepository.Query(sqlQueryOptions);
        }
    }
}