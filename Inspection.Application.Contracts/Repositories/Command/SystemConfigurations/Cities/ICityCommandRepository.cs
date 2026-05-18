using Inspection.Domain.Models.SystemConfigurations.Cities;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Cities
{
    public interface ICityCommandRepository : ICommandRepository<City>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}