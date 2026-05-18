using Inspection.Application.Contracts.Repositories.Command.DMS.Documents;
using Inspection.Domain.Models.DMS.Documents;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.DMS.Documents
{
    public class DocumentEntityLinkCommandRepository : CommandRepositoryBase<DocumentEntityLink>, IDocumentEntityLinkCommandRepository
    {
        public DocumentEntityLinkCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
    }
}
