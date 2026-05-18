using Inspection.Domain.Models.HRManagement.Departments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.HRManagement.Departments
{
    public interface IDepartmentCommandRepository : ICommandRepository<Department>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
