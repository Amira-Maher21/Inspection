using Inspection.Application.Contracts.Dto.MenuManagement;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inspection.API.Controllers.Controllers.MenuManagement
{
    [Route("api/menu/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IAccountsServicesManger _accountService;

        public MenuController(IAccountsServicesManger accountService)
        {
            _accountService = accountService;
        }


        [HttpPost]
        public async Task<IActionResult> GetMenuList(MenuRequest menuRequest)
        {
            var result = await _accountService.MenuService.GetMenuListAsync(menuRequest);

            if(result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}
