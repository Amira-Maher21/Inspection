using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.InventorySetup.UnitOfMeasureConversionConversions
{
    [Route("api/UnitOfMeasureConversion/[action]")]
    [ApiController]
    public class UnitOfMeasureConversionController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public UnitOfMeasureConversionController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UnitOfMeasureConversionCreateDto input)
        {
            var insertResult = await _servicesManger.UnitOfMeasureConversionService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UnitOfMeasureConversionUpdateDto input)
        {
            var updateResult = await _servicesManger.UnitOfMeasureConversionService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.UnitOfMeasureConversionService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.UnitOfMeasureConversionService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.UnitOfMeasureConversionService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpPatch]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicesManger.UnitOfMeasureConversionService.ImportUnitOfMeasureConversion(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.UnitOfMeasureConversionService.DownloadTemplate();

            if (!result.Succeeded)
                return BadRequest(result);

            var file = result.Result!;

            return File(
                file.Content,
                file.ContentType,
                file.FileName);
        }

    }
}