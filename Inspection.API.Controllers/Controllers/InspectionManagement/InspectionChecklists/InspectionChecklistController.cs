using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionChecklists
{


    [ApiController]
    [Route("api/InspectionChecklist/[action]")]
    public class InspectionChecklistController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public InspectionChecklistController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.InspectionChecklistService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectionChecklistService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.InspectionChecklistService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInspectionChecklistDto input)
        {
            var result = await _servicesManger.InspectionChecklistService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateInspectionChecklistDto input)
        {
            var result = await _servicesManger.InspectionChecklistService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.InspectionChecklistService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }



    }
}

