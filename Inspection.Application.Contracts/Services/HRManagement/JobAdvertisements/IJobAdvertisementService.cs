using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.HRManagement.JobAdvertisements
{
    public interface IJobAdvertisementService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateJobAdvertisementDto>> InsertJobAdvertisementTypeAsync(CreateJobAdvertisementDto insertDto);
        Task<ReturnBase<UpdateJobAdvertisementDto>> UpdateJobAdvertisementTypeAsync(UpdateJobAdvertisementDto updateDto, long id);
        Task<ReturnBase<UpdateJobAdvertisementDto>> DeleteJobAdvertisementTypeAsync(long id);
        Task<ReturnBase<JobAdvertisementDto>> GetJobAdvertisementTypeByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> GetJobAdvertisementTypeListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobAdvertisementDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
    }
}
