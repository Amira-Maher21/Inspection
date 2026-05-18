using Inspection.Domain.Models.DMS.DocumentComments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.DocumentComments
{
    public interface IDocumentCommentCommandRepository : ICommandRepository<DocumentComment>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}