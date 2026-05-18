using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.HRManagement.Employees
{
    public interface IEmployeeService : IAccountServiceBase
    {
        Task<ReturnBase<EmployeeDto>> InsertEmployeeTypeAsync(CreateEmployeeDto insertDto);
        Task<ReturnBase<EmployeeDto>> UpdateEmployeeTypeAsync(UpdateEmployeeDto updateDto, long id);
        Task<ReturnBase<EmployeeDto>> DeleteEmployeeTypeAsync(long id);
        Task<ReturnBase<EmployeeDto>> GetEmployeeTypeByIdAsync(long id);
        Task<ReturnBase<EmployeeDto>> GetByCode(string code);
        Task<ReturnBase<IEnumerable<EmployeeDto>>> GetEmployeeTypeListAsync(SqlQueryOptions sqlQueryOptions);
    }
}