using Inspection.API.Controllers.Controllers.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.MaintenanceReports
{
    [ApiController]
    [Route("api/inspection-maintenance-reports/[action]")]
    public class MaintenanceReportController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public MaintenanceReportController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpGet("{equipmentId}")]
        public async Task<IActionResult> GetByEquipmentId(Guid equipmentId)
        {
            var result = await _servicesManger.MaintenanceReportService.GetByEquipmentIdAsync(equipmentId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMaintenanceReportDto input)
        {
            var result = await _servicesManger.MaintenanceReportService.CreateAsync(input);
            return Ok(result);
        }
    }

}
