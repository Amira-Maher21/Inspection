using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.MenuManagement.Programs
{



    [Route("api/Program/[action]")]

    [ApiController]
    public class ProgramController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ProgramController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }



        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.ProgramService.GetList();

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }
    }
}
