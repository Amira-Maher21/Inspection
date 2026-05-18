using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.Assets.Setup.AssetLocations
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssetLocationController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public AssetLocationController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger ?? throw new ArgumentNullException(nameof(servicesManger));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssetLocationCreateDto input)
        {
            var result = await _servicesManger.AssetLocationService.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            AssetLocationUpdateDto input)
        {
            var result = await _servicesManger.AssetLocationService.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.AssetLocationService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.AssetLocationService.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.AssetLocationService.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

    }
}
