using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceSchedules
{
    public interface IMaintenanceScheduleCommandRepository : ICommandRepository<MaintenanceSchedule>
    {
    }
}
