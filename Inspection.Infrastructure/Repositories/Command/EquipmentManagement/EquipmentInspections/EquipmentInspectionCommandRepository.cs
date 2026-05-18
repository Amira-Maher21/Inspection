using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentInspections;
 using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
 

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentInspections
{
    public class EquipmentInspectionCommandRepository : CommandRepositoryBase<EquipmentInspection>, IEquipmentInspectionCommandRepository
    {
        public EquipmentInspectionCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
    }
}
