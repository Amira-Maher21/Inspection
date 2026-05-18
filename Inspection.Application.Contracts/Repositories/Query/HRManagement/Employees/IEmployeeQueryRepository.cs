using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.Employees;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.Employees
{
    public interface IEmployeeQueryRepository : IQueryRepository<Employee>
    {
        Task<Employee?> GetEntityByIdAsync(long id);
        Task<EmployeeDto?> GetByIdAsync(long id);
        Task<Employee?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<EmployeeDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
    }
}