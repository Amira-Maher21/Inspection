 using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.JobAdvertisements
{
    public interface IJobAdvertisementQueryRepository : IQueryRepository<JobAdvertisement>
    {
        Task<JobAdvertisement?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);

    }
}
