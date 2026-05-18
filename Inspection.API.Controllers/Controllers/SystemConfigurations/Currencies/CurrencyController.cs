using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SystemConfigurations.Currencies
{
    [Route("api/Currency/[action]")]
    [ApiController]
    public class CurrencyController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CurrencyController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CurrencyCreateDto input)
        {
            var insertResult = await _servicesManger.CurrencyService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CurrencyUpdateDto input)
        {
            var updateResult = await _servicesManger.CurrencyService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CurrencyService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CurrencyService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CurrencyService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var getResult = await _servicesManger.CurrencyService.GetByCode(code);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        //[HttpGet("Action")]
        //public async Task<IActionResult> GetIdAndName([FromQuery] SqlQueryOptions sqlQueryOptions)
        //{
        //    var getResult = await _servicesManger.CompanyService.GetIdAndName(sqlQueryOptions);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}
    }
}