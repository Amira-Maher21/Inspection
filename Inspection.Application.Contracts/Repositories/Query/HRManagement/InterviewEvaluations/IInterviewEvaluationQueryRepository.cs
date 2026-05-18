using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.InterviewEvaluations
{
    public interface IInterviewEvaluationQueryRepository : IQueryRepository<InterviewEvaluation>
    {
        Task<InterviewEvaluation?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);

    }
}
