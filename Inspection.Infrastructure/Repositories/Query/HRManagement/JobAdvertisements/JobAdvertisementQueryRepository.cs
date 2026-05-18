using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using Inspection.Infrastructure.QueryObjects.HRManagement.JobAdvertisements;
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

namespace Inspection.Infrastructure.Repositories.Query.HRManagement.JobAdvertisements
{
    internal class JobAdvertisementQueryRepository : QueryRepositoryBase<JobAdvertisement>, IJobAdvertisementQueryRepository
    {
        public JobAdvertisementQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<JobAdvertisement?> GetByIdAsync(long id)
        {
            return await _context.Set<JobAdvertisement>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new JobAdvertisementQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);//Query(CompanyDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyQueryRepository = new JobAdvertisementQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyQueryRepository.Query(queryOptions);


        }
    }
}
