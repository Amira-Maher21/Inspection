using Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.HRManagement.InterviewEvaluations
{
    public interface IInterviewEvaluationService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateInterviewEvaluationDto>> InsertInterviewEvaluationTypeAsync(CreateInterviewEvaluationDto insertDto);
        Task<ReturnBase<UpdateInterviewEvaluationDto>> UpdateInterviewEvaluationTypeAsync(UpdateInterviewEvaluationDto updateDto, long id);
        Task<ReturnBase<UpdateInterviewEvaluationDto>> DeleteInterviewEvaluationTypeAsync(long id);
        Task<ReturnBase<InterviewEvaluationDto>> GetInterviewEvaluationTypeByIdAsync(long id);
        Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> GetInterviewEvaluationTypeListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InterviewEvaluationDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
    }
}
