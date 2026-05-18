using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.MaintenanceSchedules
{
    public interface IMaintenanceScheduleService : IAccountServiceBase
    {
        Task<List<MaintenanceScheduleDto>> GetUpcomingAsync(DateTime fromDate);
        Task<MaintenanceScheduleDto> CreateAsync(CreateMaintenanceScheduleDto input);
    }
}
