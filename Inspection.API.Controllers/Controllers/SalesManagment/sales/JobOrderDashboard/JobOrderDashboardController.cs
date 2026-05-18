using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDashboard;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Inspection.API.Controllers.Controllers.SalesManagment.sales.JobOrderDashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOrderDashboardController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public JobOrderDashboardController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        // [HttpGet("GetDashboard")]
        //   public async Task<ActionResult<ReturnBase<JobOrderDashboardDto>>> GetDashboard(
        //[FromQuery] JobOrderDashboardFilterDto filter)
        //   {
        //       var result = await _servicesManger.JobOrderDashboard.GetDashboardAsync(filter);

        //       if (!result.Succeeded)
        //           return BadRequest(result.Errors);

        //       return Ok(result.Result);
        //   }


        [HttpPost]
        public async Task<IActionResult> GetDashboard(
           [FromBody] JobOrderDashboardFilterDto filter)
        {
            var result = await _servicesManger
                .JobOrderDashboard
                .GetDashboardAsync(filter);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}







