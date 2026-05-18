using Inspection.Domain.Models.DMS.Documents;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.Documents
{
    public interface IDocumentEntityLinkCommandRepository : ICommandRepository<DocumentEntityLink>
    {
    }
}
