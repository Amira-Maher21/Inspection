using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.Assets.Setup.AssetCategories
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssetCategoryController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public AssetCategoryController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger ?? throw new ArgumentNullException(nameof(servicesManger));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssetCategoryCreateDto input)
        {
            var result = await _servicesManger.AssetCategoryService.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            AssetCategoryUpdateDto input)
        {
            var result = await _servicesManger.AssetCategoryService.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.AssetCategoryService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.AssetCategoryService.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.AssetCategoryService.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPatch("Import")]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicesManger.AssetCategoryService.ImportAssetCategory(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("DownloadTemplate")]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.AssetCategoryService.DownloadTemplate();

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
