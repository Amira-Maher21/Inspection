using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.HRManagement.Department
{
    public interface IDepartmentService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateDepartmentDto>> InsertDepartmentTypeAsync(CreateDepartmentDto insertDto);
        Task<ReturnBase<UpdateDepartmentDto>> UpdateDepartmentTypeAsync(UpdateDepartmentDto updateDto, long id);
        Task<ReturnBase<UpdateDepartmentDto>> DeleteDepartmentTypeAsync(long id);
        Task<ReturnBase<DepartmentDto>> GetDepartmentTypeByIdAsync(long id);
        Task<ReturnBase<IEnumerable<DepartmentDto>>> GetDepartmentTypeListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<DepartmentDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);

    }
}
