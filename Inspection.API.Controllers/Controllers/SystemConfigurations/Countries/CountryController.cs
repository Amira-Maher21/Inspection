using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SystemConfigurations.Countries
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CountryController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger ?? throw new ArgumentNullException(nameof(servicesManger));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CountryCreateDto input)
        {
            var insertResult = await _servicesManger.CountryService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }


        [HttpPut]
        public async Task<IActionResult> Update(
    CountryUpdateDto input)
        {
            var updateResult =
                await _servicesManger.CountryService.Update(input);

            if (updateResult.Succeeded)
                return Ok(updateResult.Result);

            if (updateResult.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(updateResult.Errors);

            return BadRequest(updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CountryService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CountryService.Search(sqlQueryOptions);

            if (getResult.Succeeded)
                return Ok(getResult.Result);

            return StatusCode(500, getResult.Errors);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CountryService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var getResult = await _servicesManger.CountryService.GetByCode(code);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}