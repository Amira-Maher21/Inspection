using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.MenuManagement.User_Codes
{
    [Route("api/User_Code/[action]")]
    [ApiController]
    public class User_CodeController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public User_CodeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUser_CodeDto dto)
        {
            var result = await _servicesManger.User_CodeServise.Create(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUser_CodeDto dto)
        {
            var result = await _servicesManger.User_CodeServise.Update(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(long userId)
        {
            var result = await _servicesManger.User_CodeServise.Delete(userId);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(long userId)
        {
            var result = await _servicesManger.User_CodeServise.GetById(userId);

            if (!result.Succeeded)
                return NotFound(result.Errors);

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.User_CodeServise.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }
    }
}
