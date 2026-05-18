using Inspection.Domain.Models.DMS.DocumentShares;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.DocumentShares
{

    public interface IDocumentShareCommandRepository : ICommandRepository<DocumentShare>
    {
        Task<ReturnBase> DeleteById(long id);
    }

}
