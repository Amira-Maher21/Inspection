using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.Accounting.ChartOfAccounts
{
    [Route("api/AccountType/[action]")]
    [ApiController]
    public class AcountTypeController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public AcountTypeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getResult = await _servicesManger.AccountTypeService.GetAll();
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var getResult = await _servicesManger.AccountTypeService.GetByCode(code);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

    }
}