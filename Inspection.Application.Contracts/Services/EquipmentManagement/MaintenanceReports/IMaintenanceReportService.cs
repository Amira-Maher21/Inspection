using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.MaintenanceReports
{
    public interface IMaintenanceReportService : IAccountServiceBase
    {
        Task<List<MaintenanceReportDto>> GetByEquipmentIdAsync(Guid equipmentId);
        Task<MaintenanceReportDto> CreateAsync(CreateMaintenanceReportDto input);
    }
}
