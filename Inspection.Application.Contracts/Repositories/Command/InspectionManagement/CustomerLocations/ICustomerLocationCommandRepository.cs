using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.Locations
{
    public interface ICustomerLocationCommandRepository : ICommandRepository<CustomerLocation>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
