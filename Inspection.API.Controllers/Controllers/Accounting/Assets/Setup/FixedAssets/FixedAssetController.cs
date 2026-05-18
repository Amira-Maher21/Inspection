using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.Assets.Setup.FixedAssets
{
    [Route("api/FixedAsset/[action]")]
    [ApiController]
    public class FixedAssetController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public FixedAssetController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FixedAssetCreateDto input)
        {
            var insertResult = await _servicesManger.FixedAssetService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FixedAssetUpdateDto input)
        {
            var updateResult = await _servicesManger.FixedAssetService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.FixedAssetService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.FixedAssetService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.FixedAssetService.GetById(id);
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

            var result = await _servicesManger.FixedAssetService.ImportFixedAssets(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.FixedAssetService.DownloadTemplate();

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
