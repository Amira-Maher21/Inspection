using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionRequests
{
    [Route("api/inspection-dashboard/[action]")]
    [ApiController]
    public class InspectionDashboardController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InspectionDashboardController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> GetDashboard(
            [FromBody] InspectionDashboardFilterDto filter)
        {
            var result = await _servicesManger
                .IInspectionDashboardService
                .GetDashboardAsync(filter);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}
