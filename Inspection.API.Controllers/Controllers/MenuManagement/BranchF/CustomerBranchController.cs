using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.MenuManagement.BranchF
{
    [Route("api/setting-branch/[action]")]
    [ApiController]
    public class CustomerBranchController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public CustomerBranchController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CustomerBranchService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerBranchLookupDefualtDto>>> BranchLookupDefualt([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.CustomerBranchService.BranchLookupDefualt(sqlQueryOptions);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.CustomerBranchService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.CustomerBranchService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerBranchDto input)
        {
            var result = await _servicesManger.CustomerBranchService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCustomerBranchDto input)
        {
            var result = await _servicesManger.CustomerBranchService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.CustomerBranchService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }
    }
}

