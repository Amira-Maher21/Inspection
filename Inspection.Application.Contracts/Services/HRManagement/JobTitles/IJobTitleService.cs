using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.JobTitles;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.HRManagement.JobTitles
{
    public interface IJobTitleService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateJobTitleDto>> InsertJobTitleAsync(CreateJobTitleDto insertDto);
        Task<ReturnBase<UpdateJobTitleDto>> UpdateJobTitleAsync(UpdateJobTitleDto updateDto, long id);
        Task<ReturnBase<UpdateJobTitleDto>> DeleteJobTitleAsync(long id);
        Task<ReturnBase<JobTitleDto>> GetJobTitleByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobTitleDto>>> GetJobTitleListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobTitleLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
    }
}
