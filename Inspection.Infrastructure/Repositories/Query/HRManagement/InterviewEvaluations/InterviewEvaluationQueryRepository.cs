using Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using Inspection.Infrastructure.QueryObjects.HRManagement.InterviewEvaluations;
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

namespace Inspection.Infrastructure.Repositories.Query.HRManagement.InterviewEvaluations
{
    internal class InterviewEvaluationQueryRepository : QueryRepositoryBase<InterviewEvaluation>, IInterviewEvaluationQueryRepository
    {
        public InterviewEvaluationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<InterviewEvaluation?> GetByIdAsync(long id)
        {
            return await _context.Set<InterviewEvaluation>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new InterviewEvaluationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);//Query(CompanyDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyQueryRepository = new InterviewEvaluationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyQueryRepository.Query(queryOptions);


        }
    }
}
