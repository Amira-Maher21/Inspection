using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentsMoreInformations
{
    public class EquipmentsMoreInformationCommandRepository : CommandRepositoryBase<EquipmentsMoreInformation>, IEquipmentsMoreInformationCommandRepository
    {
        public EquipmentsMoreInformationCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
    }
}
