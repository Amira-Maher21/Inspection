using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplates
{


    public class InspectionChecklistMoreInformationTemplateCommandRepository : CommandRepositoryBase<InspectionChecklistMoreInformationTemplate>, IInspectionChecklistMoreInformationTemplateCommandRepository
    {
        public InspectionChecklistMoreInformationTemplateCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

    }
}
