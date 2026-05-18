using Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobOfferNegotiations;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using Inspection.Infrastructure.QueryObjects.HRManagement.JobOfferNegotiations;
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

namespace Inspection.Infrastructure.Repositories.Query.HRManagement.JobOfferNegotiations
{
    internal class JobOfferNegotiationQueryRepository : QueryRepositoryBase<JobOfferNegotiation>, IJobOfferNegotiationQueryRepository
    {
        public JobOfferNegotiationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<JobOfferNegotiation?> GetByIdAsync(long id)
        {
            return await _context.Set<JobOfferNegotiation>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<JobOfferNegotiationDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new JobOfferNegotiationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);//Query(CompanyDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<JobOfferNegotiationDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyQueryRepository = new JobOfferNegotiationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyQueryRepository.Query(queryOptions);


        }
    }
}
