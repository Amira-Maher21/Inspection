using Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.HRManagement.JobOfferNegotiations
{
    public interface IJobOfferNegotiationService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateJobOfferNegotiationDto>> InsertJobOfferNegotiationTypeAsync(CreateJobOfferNegotiationDto insertDto);
        Task<ReturnBase<UpdateJobOfferNegotiationDto>> DeleteJobOfferNegotiationTypeAsync(long id);
        Task<ReturnBase<JobOfferNegotiationDto>> GetJobOfferNegotiationTypeByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobOfferNegotiationDto>>> GetJobOfferNegotiationTypeListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobOfferNegotiationDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<UpdateJobOfferNegotiationDto>> UpdateJobOfferNegotiationTypeAsync(UpdateJobOfferNegotiationDto updateDto, long id);
    }
}
