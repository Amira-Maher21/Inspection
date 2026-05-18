using FluentValidation;
using Inspection.API.Controllers.Extensions;
using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Sample.CurrencyExchangeRate
{
    [Route("api/SCurrencyExchangeRate/[action]")]
    [ApiController]
    public class SCurrencyExchangeRateController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        private readonly IValidator<SCurrencyExchangeRateCreateDto> _createDtoValidator;
        private readonly IValidator<SCurrencyExchangeRateUpdateDto> _updateDtoValidator;
        public SCurrencyExchangeRateController(IAccountsServicesManger servicesManger,
                    IValidator<SCurrencyExchangeRateCreateDto> createDtoValidator,
                    IValidator<SCurrencyExchangeRateUpdateDto> updateDtoValidator)
        {
            _servicesManger = servicesManger;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var getResult = await _servicesManger.SCurrencyExchangeRateService.GetCurrencyExchangeRateById(id);
                if (getResult.Succeeded)
                    return Ok(getResult.Result);
                else
                    return BadRequest(getResult.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}/lines")]
        public async Task<IActionResult> GetLines(long id)
        {
            try
            {
                var listResult = await _servicesManger.SCurrencyExchangeRateService.GetCurrencyExchangeRatesLinesAsync(id);
                if (listResult.Succeeded)
                    return Ok(listResult.Result);
                else
                    return BadRequest(listResult.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(SqlQueryOptions queryOptions)
        {
            try
            {
                var listResult = await _servicesManger.SCurrencyExchangeRateService.GetCurrencyExchangeRateListAsync(queryOptions);
                if (listResult.Succeeded)
                    return Ok(listResult.Result);
                else
                    return BadRequest(listResult.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SCurrencyExchangeRateCreateDto dto)
        {
            var validationResult = await _createDtoValidator.ValidateAsync(dto);
            if (validationResult.IsValid)
            {
                try
                {
                    var createResult = await _servicesManger.SCurrencyExchangeRateService.CreateCurrencyExchangeRateAsync(dto);
                    if (!createResult.Succeeded)
                    {
                        return BadRequest(createResult.Errors);
                    }
                    return Ok(createResult.Result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }


            }
            return BadRequest(validationResult.GetValidationErrors());
        }

        [HttpPut]
        public async Task<IActionResult> Update(SCurrencyExchangeRateUpdateDto dto)
        {
            var validationResult = await _updateDtoValidator.ValidateAsync(dto);
            if (validationResult.IsValid)
            {
                try
                {
                    var updateResult = await _servicesManger.SCurrencyExchangeRateService.UpdateCurrencyExchangeRateAsync(dto);
                    if (!updateResult.Succeeded)
                    {
                        return BadRequest(updateResult.Errors);
                    }
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return BadRequest(validationResult.GetValidationErrors());
        }

        [HttpPost("{id}/lines")]
        public async Task<IActionResult> AddLine(long id, SCurrencyExchangeRateAddLineDto dto)
        {
            try
            {
                var addLineResult = await _servicesManger.SCurrencyExchangeRateService.AddCurrencyExchangeRateLineAsync(id, dto);
                if (!addLineResult.Succeeded)
                {
                    return BadRequest(addLineResult.Errors);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}/lines")]
        public async Task<IActionResult> UpdateLine(long id, SCurrencyExchangeRateUpdateLineDto dto)
        {
            try
            {
                var updateLineResult = await _servicesManger.SCurrencyExchangeRateService.UpdateCurrencyExchangeRateLineAsync(id, dto);
                if (!updateLineResult.Succeeded)
                {
                    return BadRequest(updateLineResult.Errors);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(long id)
        {
            try
            {
                var deactivateResult = await _servicesManger.SCurrencyExchangeRateService.DeactivateCurrencyExchangeRateAsync(id);
                if (!deactivateResult.Succeeded)
                {
                    return BadRequest(deactivateResult.Errors);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}