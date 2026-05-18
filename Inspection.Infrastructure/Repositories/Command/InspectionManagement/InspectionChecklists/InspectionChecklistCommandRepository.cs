using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklists;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklists
{


    public class InspectionChecklistCommandRepository : CommandRepositoryBase<InspectionChecklist>, IInspectionChecklistCommandRepository
    {
        public InspectionChecklistCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
    }
}
