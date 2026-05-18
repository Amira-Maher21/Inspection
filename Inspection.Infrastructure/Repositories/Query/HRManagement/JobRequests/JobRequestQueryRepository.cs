using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobRequests;
using Inspection.Domain.Models.HRManagement.JobRequests;
using Inspection.Domain.Models.HRManagement.JobRequests;
using Inspection.Infrastructure.QueryObjects.HRManagement.JobRequests;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.HRManagement.JobRequests
{
    public class JobRequestQueryRepository : QueryRepositoryBase<JobRequest>, IJobRequestQueryRepository
    {
        public JobRequestQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<JobRequest?> GetByIdAsync(long id)
        {
            return await _context.Set<JobRequest>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<JobRequestDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new JobRequestQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);//Query(CompanyDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<JobRequestDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyQueryRepository = new JobRequestQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyQueryRepository.Query(queryOptions);


        }
    }
}
