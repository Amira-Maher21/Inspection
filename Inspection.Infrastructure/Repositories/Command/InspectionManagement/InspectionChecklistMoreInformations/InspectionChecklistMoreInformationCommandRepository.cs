using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformations
{


    namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.InspectionChecklistMoreInformations
    {
        public class InspectionChecklistMoreInformationCommandRepository : CommandRepositoryBase<InspectionChecklistMoreInformation>, IInspectionChecklistMoreInformationCommandRepository
        {
            public InspectionChecklistMoreInformationCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
            {

                _entityStructure = new EntityStructure
                {
                    Key = ["Id"]
                };
            }
        }
    }
}