using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceSchedules;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules;
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

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.MaintenanceSchedules
{
    public class MaintenanceScheduleCommandRepository : CommandRepositoryBase<MaintenanceSchedule>, IMaintenanceScheduleCommandRepository
    {
        public MaintenanceScheduleCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
    }
}
