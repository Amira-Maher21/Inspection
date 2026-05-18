using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.AccountSetup.AccountingPeriods
{
    [Route("api/AccountingPeriod/[action]")]
    [ApiController]
    public class AccountingPeriodController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public AccountingPeriodController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountingPeriodCreateDto input)
        {
            var insertResult = await _servicesManger.AccountingPeriodService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AccountingPeriodUpdateDto input)
        {
            var updateResult = await _servicesManger.AccountingPeriodService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.AccountingPeriodService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.AccountingPeriodService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.AccountingPeriodService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        //[HttpPatch]
        //public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _servicesManger.CostUnitService.ImportCostUnits(dto);

        //    if (!result.Succeeded)
        //        return StatusCode(500, result.Errors);

        //    return Ok(result.Result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> DownloadTemplate()
        //{
        //    var result = await _servicesManger.CostUnitService.DownloadTemplate();

        //    if (!result.Succeeded)
        //        return BadRequest(result);

        //    var file = result.Result!;

        //    return File(
        //        file.Content,
        //        file.ContentType,
        //        file.FileName);
        //}
    }
}