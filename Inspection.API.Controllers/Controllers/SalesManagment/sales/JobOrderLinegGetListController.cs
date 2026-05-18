using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Inspection.API.Controllers.Controllers.SalesManagment.sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOrderLinegetListController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public JobOrderLinegetListController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.JobOrderDetailService.GetJobOrderDetailsListAsync();

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}
