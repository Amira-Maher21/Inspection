using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;

namespace Inspection.API.Controllers.Controllers.LocalizationManagement
{
    [Route("api/localization/[action]")]
    public class LocalizationController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _accountService;

        public LocalizationController(IAccountsServicesManger accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CreateLocalizationDto insertDto)
        {
            var insertResult = await _accountService.LocalizationService.InsertLocalizationAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateLocalizationDto updateDto)
        {
            var updateResult = await _accountService.LocalizationService.UpdateLocalizationAsync(updateDto);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EntityKeyValueDictionary keys)
        {
            var deleteResult = await _accountService.LocalizationService.DeleteLocalizationAsync(keys);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _accountService.LocalizationService.GetLocalizationListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> GetList()
        {
            var getResult = await _accountService.LocalizationService.GetList();
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}
