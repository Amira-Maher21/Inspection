using Inspection.Domain.Models.Contracting.Setup.Divisions;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.Divisions
{
    public interface IDivisionCommandRepository : ICommandRepository<Division>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);
    }
}