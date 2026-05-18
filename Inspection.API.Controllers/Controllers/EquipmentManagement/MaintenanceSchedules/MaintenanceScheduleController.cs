using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.MaintenanceSchedules
{
    [ApiController]
    [Route("api/inspection-maintenance-schedules/[action]")]
    public class MaintenanceScheduleController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public MaintenanceScheduleController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcoming([FromQuery] DateTime fromDate)
        {
            var result = await _servicesManger.MaintenanceScheduleService.GetUpcomingAsync(fromDate);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMaintenanceScheduleDto input)
        {
            var result = await _servicesManger.MaintenanceScheduleService.CreateAsync(input);
            return Ok(result);
        }
    }

}
