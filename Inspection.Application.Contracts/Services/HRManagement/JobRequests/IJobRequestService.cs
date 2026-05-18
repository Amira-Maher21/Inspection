using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.HRManagement.JobRequests
{
    public interface IJobRequestService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateJobRequestDto>> InsertJobRequestAsync(CreateJobRequestDto insertDto);
        Task<ReturnBase<UpdateJobRequestDto>> UpdateJobRequestAsync(UpdateJobRequestDto updateDto, long id);
        Task<ReturnBase<UpdateJobRequestDto>> DeleteJobRequestAsync(long id);
        Task<ReturnBase<JobRequestDto>> GetJobRequestByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobRequestDto>>> GetJobRequestListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobRequestLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<bool>> ChangeStatus(long id, ChangejobRequestStatus Status);
    }
}
