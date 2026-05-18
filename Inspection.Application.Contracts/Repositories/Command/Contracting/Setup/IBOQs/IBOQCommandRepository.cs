using Inspection.Domain.Models.Contracting.Setup.BOQs;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.IBOQs
{
    public interface IBOQCommandRepository : ICommandRepository<BOQ>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteBOQLinesByBOQIds(List<long> ids);
    }
}