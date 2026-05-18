using Inspection.Domain.Models.Contracting.Setup.WBSs;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Contracting.WBSs
{
    public interface IWBSCommandRepository : ICommandRepository<WBS>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);
    }
}