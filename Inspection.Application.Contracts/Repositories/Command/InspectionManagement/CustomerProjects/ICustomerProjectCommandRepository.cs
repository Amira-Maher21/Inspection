using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.CustomerProjects
{
    public interface ICustomerProjectCommandRepository : ICommandRepository<CustomerProject>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
