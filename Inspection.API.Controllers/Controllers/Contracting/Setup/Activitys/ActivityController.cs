using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Contracting.Setup.Activitys
{
    [Route("api/Activity/[action]")]
    [ApiController]
    public class ActivityController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ActivityController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityCreateDto input)
        {
            var result = await _servicesManger.ActivityService.Create(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ActivityUpdaeDto input)
        {
            var result = await _servicesManger.ActivityService.Update(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.ActivityService.Delete(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions options)
        {
            var result = await _servicesManger.ActivityService.Search(options);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.ActivityService.GetById(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}