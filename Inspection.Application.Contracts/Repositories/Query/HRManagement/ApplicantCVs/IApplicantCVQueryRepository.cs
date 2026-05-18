using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.ApplicantCVs
{
    public interface IApplicantCVQueryRepository : IQueryRepository<ApplicantCV>
    {
        Task<ApplicantCV?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<ApplicantCVDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<ApplicantCVDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);

    }
}
