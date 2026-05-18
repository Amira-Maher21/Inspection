
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.CustomerLocations
{
    [Route("api/CustomerLocation/[action]")]
    [ApiController]
    public class CustomerLocationController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CustomerLocationController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerLocationDto insertDto)
        {
            var insertResult = await _servicesManger.CustomerLocationService.InsertCustomerLocationAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateCustomerLocationDto updateDto, long id)
        {
            var updateResult = await _servicesManger.CustomerLocationService.UpdateCustomerLocationAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CustomerLocationService.DeleteCustomerLocationAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _servicesManger.CustomerLocationService.GetListAsync();
        //    return Ok(list);
        //}


        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CustomerLocationService.GetCustomerLocationListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CustomerLocationService.GetCustomerLocationByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> LookUpCustomerLocationForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CustomerLocationService.GetLookUpCustomerLocationForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

    }
}
