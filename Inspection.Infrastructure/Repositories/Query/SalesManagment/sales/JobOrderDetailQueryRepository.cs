using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.sales
{

    public class JobOrderDetailQueryRepository : QueryRepositoryBase<JobOrderLine>, IJobOrderDetailQueryRepository
    {
        public JobOrderDetailQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<JobOrderLine?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        //public async Task<IEnumerable<JobOrderDetailIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    var JobOrderDetailQueryRep = new JobOrderDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    var result = await JobOrderDetailQueryRep.Query(sqlQueryOptions);
        //    return result.Result;
        //}
        //public async Task<ReturnBase<IEnumerable<JobOrderDetailIncludeDto>>> GetLookUpJobOrderDetailForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var JobOrderDetailQueryRepository = new JobOrderDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

        //    return await JobOrderDetailQueryRepository.Query(queryOptions);


        //}

        public async Task<IEnumerable<JobOrderLinegGetListDto>> GetListAsync()
        {
            return await _dbSet
                .Include(x => x.Inspectors)
                .Select(x => new JobOrderLinegGetListDto
                {
                    Id = x.Id,
                    InspectorId = x.InspectorId,

                    Code = x.Inspectors.Code,
                    FirstName = x.Inspectors.FirstName,
                    LastName = x.Inspectors.LastName,

                    ScheduledFromTime = x.ScheduledFromTime,
                    ScheduledToTime = x.ScheduledToTime
                })
                .ToListAsync();
        }

        //public async Task<IEnumerable<JobOrderLinegGetListDto>> GetListAsync()
        //{
        //    return await _dbSet
        //        .Select(x => new JobOrderLinegGetListDto
        //        {
        //            Id = x.Id,
        //            InspectorId = x.InspectorId,
        //            Code = x.Inspectors.Code,
        //            InspectorName = x.Inspectors.FirstName + " " + x.Inspectors.LastName,
        //            ScheduledFromTime = x.ScheduledFromTime,
        //            ScheduledToTime = x.ScheduledToTime
        //        })
        //        .ToListAsync();

        //}
    }
}
