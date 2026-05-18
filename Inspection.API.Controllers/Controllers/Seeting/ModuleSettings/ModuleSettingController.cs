using Inspection.Application.Contracts.Dto.Setting.ModuleSettings;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Seeting.ModuleSetting
{
    [Route("api/ModuleSetting/[action]")]
    [ApiController]
    public class ModuleSettingController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ModuleSettingController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModuleSettingCreateDto dto)
        {
            var result = await _servicesManger.ModuleSetting.Create(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ModuleSettingUpdateDto dto)
        {
            var result = await _servicesManger.ModuleSetting.Update(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.ModuleSetting.Delete(id);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.ModuleSetting.GetById(id);

            if (!result.Succeeded)
                return NotFound(result.Errors);

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.ModuleSetting.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }
    }
}
