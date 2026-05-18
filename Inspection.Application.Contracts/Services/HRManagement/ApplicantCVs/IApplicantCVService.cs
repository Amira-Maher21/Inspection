using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.HRManagement.ApplicantCVs
{
    public interface IApplicantCVService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateApplicantCVDto>> InsertApplicantCVTypeAsync(CreateApplicantCVDto insertDto);
        Task<ReturnBase<UpdateApplicantCVDto>> UpdateApplicantCVTypeAsync(UpdateApplicantCVDto updateDto, long id);
        Task<ReturnBase<UpdateApplicantCVDto>> DeleteApplicantCVTypeAsync(long id);
        Task<ReturnBase<ApplicantCVDto>> GetApplicantCVTypeByIdAsync(long id);
        Task<ReturnBase<IEnumerable<ApplicantCVDto>>> GetApplicantCVTypeListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<ApplicantCVDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<bool>> ChangeStatus(long id, ChangeApplicantStatusRequest Status);
    }
}
