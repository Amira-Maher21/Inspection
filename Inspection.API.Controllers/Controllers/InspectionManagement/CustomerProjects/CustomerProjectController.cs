using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.CustomerProjects
{
    [Route("api/CustomerProject/[action]")]
    [ApiController]
    public class CustomerProjectController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CustomerProjectController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerProjectDto insertDto)
        {
            var insertResult = await _servicesManger.CustomerProjectService.InsertCustomerProjectAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateCustomerProjectDto updateDto, long id)
        {
            var updateResult = await _servicesManger.CustomerProjectService.UpdateCustomerProjectAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CustomerProjectService.DeleteCustomerProjectAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _servicesManger.CustomerProjectService.GetListAsync();
        //    return Ok(list);
        //}



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CustomerProjectService.GetCustomerProjectByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CustomerProjectService.GetCustomerProjectListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }


        [HttpGet]
        public async Task<IActionResult> LookUpCustomerProjectForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CustomerProjectService.GetLookUpCustomerProjectForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

    }
}
