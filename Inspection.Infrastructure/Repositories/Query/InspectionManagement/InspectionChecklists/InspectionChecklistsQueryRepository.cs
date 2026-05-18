using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklists;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionChecklists;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionChecklistsQueryRepository
{


    public class InspectionChecklistsQueryRepository : QueryRepositoryBase<InspectionChecklist>, IInspectionChecklistsQueryRepository
    {
        public InspectionChecklistsQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<InspectionChecklist?> GetByIdAsync(long id) =>
            await _dbSet.Include(x => x.InspectionChecklistMoreInformations).ThenInclude(x => x.InspectionChecklistMoreInformationDetails).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);


        //public async Task<List<InspectionChecklist>> GetExpiringSoonAsync(int days)
        //{
        //    var now = DateTime.UtcNow;
        //    return await _dbSet
        //        .Where(x => x.ExpiryDate != null && (x.ExpiryDate.Value - now).TotalDays <= days)
        //        .ToListAsync();
        //}

        //public async Task<List<InspectionChecklist>> GetNeedingMaintenanceSoonAsync(int days)
        //{
        //    var now = DateTime.UtcNow;
        //    return await _dbSet
        //        .Where(x =>
        //            x.LastMaintenanceDate != null

        //        ).ToListAsync();
        //}


        public async Task<IEnumerable<InspectionChecklistDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionChecklistQueryRepository = new InspectionChecklistsQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await InspectionChecklistQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }


    }
}
