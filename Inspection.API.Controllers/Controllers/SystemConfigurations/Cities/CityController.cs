using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SystemConfigurations.Cities
{
    [Route("api/City/[action]")]
    [ApiController]
    public class CityController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CityController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityCreateDto input)
        {
            var insertResult = await _servicesManger.CityService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CityUpdateDto input)
        {
            var updateResult = await _servicesManger.CityService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CityService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CityService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CityService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var getResult = await _servicesManger.CityService.GetByCode(code);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        //[HttpPost("Import")]
        //[RequestSizeLimit(50_000_000)]
        //public async Task<IActionResult> Import([FromForm] IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return BadRequest("No file uploaded.");

        //    var importResult = await _servicesManger.CompanyService.ImportFromExcel(file);

        //    if (!importResult.Succeeded)
        //        return StatusCode(500, importResult.Errors);

        //    return Ok(importResult.Result);
        //}
        [HttpPatch("Import")]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicesManger.CompanyService.ImportCompanies(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.CityService.DownloadTemplate();

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