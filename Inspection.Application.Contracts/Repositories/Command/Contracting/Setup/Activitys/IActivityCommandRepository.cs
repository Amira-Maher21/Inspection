using Inspection.Domain.Models.Contracting.Setup.Activitys;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.Activitys
{
    public interface IActivityCommandRepository : ICommandRepository<Activity>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
