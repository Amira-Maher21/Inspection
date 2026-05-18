using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.Assets.AssetAccountingEventAccounts
{
    [Route("api/AssetAccountingEventAccount/[action]")]
    [ApiController]
    public class AssetAccountingEventAccountController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public AssetAccountingEventAccountController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssetAccountingEventAccountCreateDto input)
        {
            var insertResult = await _servicesManger.AssetAccountingEventAccountService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AssetAccountingEventAccountUpdateDto input)
        {
            var updateResult = await _servicesManger.AssetAccountingEventAccountService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.AssetAccountingEventAccountService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.AssetAccountingEventAccountService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.AssetAccountingEventAccountService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }




    }
}