using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using Inspection.Domain.Models.HRManagement.JobRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.JobRequests
{
    public interface IJobRequestQueryRepository : IQueryRepository<JobRequest>
    {
        Task<JobRequest?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobRequestDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobRequestDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
    }
}
