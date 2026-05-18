using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inspection.Techinal.Inspector
{
    [Route("api/Inspector/[action]")]
    [ApiController]
    public class InspectorController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InspectorController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InspectorCreateDto input)
        {
            var insertResult = await _servicesManger.InspectorService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(InspectorUpdateDto input)
        {
            var updateResult = await _servicesManger.InspectorService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.InspectorService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectorService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.InspectorService.GetById(id);
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

            var result = await _servicesManger.InspectorService.ImportInspectors(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.InspectorService.DownloadTemplate();

            if (!result.Succeeded)
                return BadRequest(result);

            var file = result.Result!;

            return File(
                file.Content,
                file.ContentType,
                file.FileName);
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.InspectorService.GetListAsync();

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }


    }
}