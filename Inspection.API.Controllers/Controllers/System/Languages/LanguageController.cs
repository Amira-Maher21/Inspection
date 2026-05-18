using Inspection.Application.Contracts.Dto.SystemDto.Languages;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.System.Languages
{
    [Route("api/Language/[action]")]
    [ApiController]
    public class LanguageController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public LanguageController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            var result = await _servicesManger.Languages.Create(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LanguageUpdateDto dto)
        {
            var result = await _servicesManger.Languages.Update(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpDelete("{localeCode}")]
        public async Task<IActionResult> Delete(string localeCode)
        {
            var result = await _servicesManger.Languages.Delete(localeCode);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("{localeCode}")]
        public async Task<IActionResult> GetById(string localeCode)
        {
            var result = await _servicesManger.Languages.GetById(localeCode);

            if (!result.Succeeded)
                return NotFound(result.Errors);

            return Ok(result.Result);
        }




        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.Languages.GetList();

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList([FromQuery] SqlQueryOptions options)
        //{
        //    var result = await _servicesManger.Languages.GetList(options);

        //    if (!result.Succeeded)
        //        return BadRequest(result.Errors);

        //    return Ok(result.Result);
        //}

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.Languages.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }
    }
}