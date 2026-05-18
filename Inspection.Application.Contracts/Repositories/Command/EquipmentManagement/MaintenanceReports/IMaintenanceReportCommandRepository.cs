using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceReports
{
    public interface IMaintenanceReportCommandRepository : ICommandRepository<MaintenanceReport>
    {
    }
}
