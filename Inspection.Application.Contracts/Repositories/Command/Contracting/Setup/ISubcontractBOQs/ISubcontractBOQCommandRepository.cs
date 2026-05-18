using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.ISubcontractBOQs
{
    public interface ISubcontractBOQCommandRepository : ICommandRepository<SubcontractBOQ>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteSubcontractBOQLinesBySubcontractBOQIds(List<long> ids);
    }
}