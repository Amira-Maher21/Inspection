using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Dto.HRManagement.JobTitles;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.JobTitles;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.JobTitles
{
    public interface IJobTitleQueryRepository : IQueryRepository<JobTitle>
    {
        Task<JobTitle?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobTitleDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobTitleDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
    }
}
