using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateTemplateTemplates;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplates
{

    public class EquipmentsMoreInformationTemplateCommandRepository : CommandRepositoryBase<EquipmentsMoreInformationTemplate>, IEquipmentsMoreInformationTemplateCommandRepository
    {
        public EquipmentsMoreInformationTemplateCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

    }
}
