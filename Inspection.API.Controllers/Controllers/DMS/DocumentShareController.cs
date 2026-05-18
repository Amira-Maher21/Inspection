using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.DMS
{

    [Route("api/DocumentShare/[action]")]
    [ApiController]
    public class DocumentShareController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public DocumentShareController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentShareCreateDto dto)
        {
            var result = await _servicesManger.DocumentShareService.Create(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DocumentShareUpdateDto dto)
        {
            var result = await _servicesManger.DocumentShareService.Update(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.DocumentShareService.Delete(id);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.DocumentShareService.GetById(id);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.DocumentShareService.GetList();

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.DocumentShareService.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }
    }
}
