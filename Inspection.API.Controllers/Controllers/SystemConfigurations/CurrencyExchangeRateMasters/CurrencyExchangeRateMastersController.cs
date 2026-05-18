using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.SystemConfigurations.CurrencyExchangeRateMasters
{

    [Route("api/CurrencyExchangRate/[action]")]
    [ApiController]
    public class CurrencyExchangeRateMastersController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CurrencyExchangeRateMastersController(
            IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
           CurrencyExchangeRateMasterCreateDto input)
        {
            var insertResult =
                await _servicesManger.CurrencyExchangeRateMasteService.Create(input);

            if (insertResult.Succeeded)
                return Ok(insertResult.Result);

            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
    [FromBody] CurrencyExchangeRateMasterUpdateDto input)
        {
            var updateResult =
                await _servicesManger.CurrencyExchangeRateMasteService.Update(input);

            if (updateResult.Succeeded)
                return Ok(updateResult.Result);

            return StatusCode(500, updateResult.Errors);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult =
                await _servicesManger.CurrencyExchangeRateMasteService.Delete(id);

            if (deleteResult.Succeeded)
                return Ok(deleteResult.Result);

            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(
           SqlQueryOptions sqlQueryOptions)
        {
            var getResult =
                await _servicesManger.CurrencyExchangeRateMasteService.Search(sqlQueryOptions);

            if (getResult.Succeeded)
                return Ok(getResult.Result);

            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult =
                await _servicesManger.CurrencyExchangeRateMasteService.GetById(id);

            if (getResult.Succeeded)
                return Ok(getResult.Result);

            return StatusCode(500, getResult.Errors);
        }
    }
}
