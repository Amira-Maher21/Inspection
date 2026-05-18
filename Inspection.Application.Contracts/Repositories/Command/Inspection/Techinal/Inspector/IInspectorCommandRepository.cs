using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
namespace Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Inspector
{
    public interface IInspectorCommandRepository : ICommandRepository<Domain.Models.Inspection.Techinal.Inspectors.Inspector>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
