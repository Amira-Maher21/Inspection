using Inspection.Application.Contracts.Dto.MenuManagement.AreaF;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.MenuManagement.AreaF
{
    [Route("api/setting-area/[action]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public AreaController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.AreaService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<ActionResult<List<AreaLookupDefaultDto>>> AreaLookupDefault([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.AreaService.AreaLookupDefault(sqlQueryOptions);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.AreaService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.AreaService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAreaDto input)
        {
            var result = await _servicesManger.AreaService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateAreaDto input)
        {
            var result = await _servicesManger.AreaService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.AreaService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }
    }
}
