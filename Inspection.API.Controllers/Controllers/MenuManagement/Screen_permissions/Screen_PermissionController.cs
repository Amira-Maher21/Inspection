using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.MenuManagement.Screen_permissions
{

    [Route("api/Screen_permission/[action]")]
    [ApiController]
    public class Screen_PermissionController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public Screen_PermissionController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateScreen_permissionDto insertDto)
        {
            var insertResult = await _servicesManger.Screen_permissionService.InsertScreen_permissionAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateScreen_permissionDto updateDto)
        {
            var updateResult = await _servicesManger.Screen_permissionService.UpdateScreen_permissionAsync(updateDto);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteResult = await _servicesManger.Screen_permissionService.DeleteScreen_permissionAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _servicesManger.Screen_permissionService.GetListAsync();
        //    return Ok(list);
        //}



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var getResult = await _servicesManger.Screen_permissionService.GetScreen_permissionByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.Screen_permissionService.GetScreen_permissionListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }


        //[HttpGet]
        //public async Task<IActionResult> LookUpScreen_permissionForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        //{
        //    var getResult = await _servicesManger.Screen_permissionService.GetLookUpScreen_permissionForNamesAsync(sqlQueryOptions);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}

    }
}
