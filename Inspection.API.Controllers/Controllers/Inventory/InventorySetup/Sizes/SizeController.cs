using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.InventorySetup.Sizes
{
    [Route("api/Size/[action]")]

    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public SizeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SizeCreateDto input)
        {
            var result = await _servicesManger.SizeService.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]

        public async Task<IActionResult> Update([FromBody] SizeUpdateDto input)
        {
            var result = await _servicesManger.SizeService.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.SizeService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.SizeService.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.SizeService.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }



        [HttpPatch]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicesManger.SizeService.ImportSize(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.SizeService.DownloadTemplate();

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
