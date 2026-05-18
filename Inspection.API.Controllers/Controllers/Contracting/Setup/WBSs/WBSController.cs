using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Contracting.Setup.WBSs
{
    [Route("api/WBS/[action]")]
    [ApiController]
    public class WBSController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public WBSController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(WBSCreateDto input)
        {
            var result = await _servicesManger.WBSService.Create(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(WBSUpdateDto input)
        {
            var result = await _servicesManger.WBSService.Update(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.WBSService.Delete(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions options)
        {
            var result = await _servicesManger.WBSService.Search(options);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.WBSService.GetById(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}