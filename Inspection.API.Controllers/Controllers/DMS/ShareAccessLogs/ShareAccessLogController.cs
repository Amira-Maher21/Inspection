using Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.DMS.ShareAccessLogs
{


    [Route("api/ShareAccessLog/[action]")]
    [ApiController]
    public class ShareAccessLogController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ShareAccessLogController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShareAccessLogCreateDto dto)
        {
            var result = await _servicesManger.ShareAccessLogService.Create(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ShareAccessLogUpdateDto dto)
        {
            var result = await _servicesManger.ShareAccessLogService.Update(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.ShareAccessLogService.Delete(id);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.ShareAccessLogService.GetById(id);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.ShareAccessLogService.GetList();

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.ShareAccessLogService.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }
    }
}


