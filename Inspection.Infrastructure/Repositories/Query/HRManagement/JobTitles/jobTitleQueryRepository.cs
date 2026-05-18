using Inspection.Application.Contracts.Dto.HRManagement.JobTitles;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobTitles;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.JobTitles;
using Inspection.Infrastructure.QueryObjects.HRManagement.JobTitles;
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

namespace Inspection.Infrastructure.Repositories.Query.HRManagement.JobTitles
{
    public class jobTitleQueryRepository : QueryRepositoryBase<JobTitle>, IJobTitleQueryRepository
    {
        public jobTitleQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<JobTitle?> GetByIdAsync(long id)
        {
            return await _context.Set<JobTitle>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<JobTitleDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new JobTitleQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);//Query(CompanyDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<JobTitleDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyQueryRepository = new JobTitleQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyQueryRepository.Query(queryOptions);


        }
    }
}
