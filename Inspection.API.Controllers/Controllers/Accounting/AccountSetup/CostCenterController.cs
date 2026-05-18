using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Accounting.AccountSetup
{
    [Route("api/CostCenter/[action]")]
    [ApiController]
    public class CostCenterController : ControllerBase
    {
        private readonly ICostCenterService _service;


        private readonly IAccountsServicesManger _servicesManger;

        public CostCenterController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CostCenterCreateDto input)
        {
            var insertResult = await _servicesManger.CostCenterService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CostCenterUpdateDto input)
        {
            var updateResult = await _servicesManger.CostCenterService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CostCenterService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CostCenterService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CostCenterService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var getResult = await _servicesManger.CostCenterService.GetByCode(code);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPatch("Import")]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicesManger.CostCenterService.ImportCostCenter(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("DownloadTemplate")]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.CostCenterService.DownloadTemplate();

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var file = result.Result!;

            return File(
                file.Content,
                file.ContentType,
                file.FileName);
        }
    }
}