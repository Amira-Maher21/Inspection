using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.MenuManagement.User_Groups
{

    [Route("api/User_Group")]
    [ApiController]
    public class User_GroupController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public User_GroupController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        // ============ CREATE ============
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUser_GroupDto dto)
        {
            var result = await _servicesManger.User_GroupService.Create(dto);
            return result.Succeeded
                ? Ok(result.Result)
                : StatusCode(500, result.Errors);
        }

        // ============ UPDATE ============
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUser_GroupDto dto)
        {
            var result = await _servicesManger.User_GroupService.Update(dto);
            return result.Succeeded
                ? Ok(result.Result)
                : StatusCode(500, result.Errors);
        }

        // ============ DELETE ============
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.User_GroupService.Delete(id);
            return result.Succeeded
                ? Ok(result.Result)
                : StatusCode(500, result.Errors);
        }

        // ============ GET BY ID ============
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.User_GroupService.GetById(id);
            return result.Succeeded
                ? Ok(result.Result)
                : StatusCode(500, result.Errors);
        }

        // ============ SEARCH ============
        //[HttpGet("Search")]
        //public async Task<IActionResult> Search([FromQuery] SqlQueryOptions sqlQueryOptions)
        //{
        //    var result = await _servicesManger.User_GroupService.Search(sqlQueryOptions);
        //    return result.Succeeded
        //        ? Ok(result.Result)
        //        : StatusCode(500, result.Errors);
        //}


        [HttpPost("Search")]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.User_GroupService.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }
    }
}
