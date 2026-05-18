using Inspection.Domain.Models.DMS.Documents;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.Documents
{
    public interface IDocumentCommandRepository : ICommandRepository<Document>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteDocumentEntityLinkByDocumentId(long documentId);
        Task<ReturnBase> DeleteDocumentEntityLinksByIds(List<long> ids);
    }
}