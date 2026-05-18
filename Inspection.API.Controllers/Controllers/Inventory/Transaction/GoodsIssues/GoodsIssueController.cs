using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.Transaction.GoodsIssues
{
    [Route("api/GoodsIssue/[action]")]
    [ApiController]
    public class GoodsIssueController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public GoodsIssueController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(GoodsIssueCreateDto input)
        {
            var result = await _servicesManger.GoodsIssue.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GoodsIssueUpdateDto input)
        {
            var result = await _servicesManger.GoodsIssue.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.GoodsIssue.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.GoodsIssue.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions options)
        {
            var result = await _servicesManger.GoodsIssue.Search(options);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPatch]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicesManger.GoodsIssue.ImportGoodsIssue(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.GoodsIssue.DownloadGoodsIssueTemplate();

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