using Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs;
using Inspection.Application.Contracts.Repositories.Query.DMS.ShareAccessLogs;
using Inspection.Domain.Models.DMS.ShareAccessLogs;
using Inspection.Infrastructure.QueryObjects.DMS.ShareAccessLogs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.DMS.ShareAccessLogs
{

    public class ShareAccessLogQueryRepository : QueryRepositoryBase<ShareAccessLog>, IShareAccessLogQueryRepository
    {
        public ShareAccessLogQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<ShareAccessLog?> GetById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ShareAccessLog>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet.ToListAsync();
        }


        //public async Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId)
        //{
        //    try
        //    {
        //        var query = _context.Set<ShareAccessLog>()
        //            .AsNoTracking()
        //            .Where(t =>
        //                t.Tenant_ID == tenantId &&
        //                t.CompanyId == companyId);

        //        var result = await query
        //            .Select(t => new ShareAccessLogReturnSearchDto
        //            {
        //                Id = t.Id,
        //                Tenant_ID = t.Tenant_ID,
        //                CompanyId = t.CompanyId,
        //                //Name = t.Name,
        //                //Color = t.Color,

        //                In_User = t.In_User,
        //                In_Date = t.In_Date,
        //                Mod_User = t.Mod_User,
        //                Mod_Date = t.Mod_Date
        //            })
        //            .ToListAsync();

        //        return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>
        //            .Success(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>
        //            .Fail(ex, _exceptionManager);
        //    }
        //}



        public async Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var TaxQueryRepository = new ShareAccessLogQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await TaxQueryRepository.Query(sqlQueryOptions);
        }
    }

}
