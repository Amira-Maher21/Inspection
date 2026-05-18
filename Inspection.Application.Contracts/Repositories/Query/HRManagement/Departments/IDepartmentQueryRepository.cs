using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.Departments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.Departments
{
    public interface IDepartmentQueryRepository : IQueryRepository<Department>
    {
        Task<Department?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<DepartmentDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<DepartmentDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);
    }
}
