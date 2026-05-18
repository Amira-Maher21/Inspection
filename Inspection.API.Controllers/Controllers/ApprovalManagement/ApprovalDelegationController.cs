using Inspection.API.Controllers.AppControllersBase;
using Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;

namespace Inspection.API.Controllers.Controllers.ApprovalManagement
{
    [Route("api/approvaldelegation/[action]")]

    public class ApprovalDelegationController : AccountsControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ApprovalDelegationController(IAccountsServicesManger servicesManger)
        {
            this._servicesManger = servicesManger;
        }


        [HttpPost]
        public async Task<ActionResult> Index(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.ApprovalDelegationService.GetApprovalDelegationIndexAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ApprovalDelegationInsertDto insertDto)
        {
            var insertResult = await this._servicesManger.ApprovalDelegationService.InsertApprovalDelegationAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Entity(EntityKeyValueDictionary keys)
        {
            var getEntityResult = await this._servicesManger.ApprovalDelegationService.GetApprovalDelegationEntityAsync(keys);
            if (getEntityResult.Succeeded)
            {
                return Ok(getEntityResult.Result);
            }
            return StatusCode(500, getEntityResult.Errors);
        }

        //[HttpPost]
        //public async Task<ActionResult> Delete(EntityKeyValueDictionary keys)
        //{
        //    var deleteResult = await this._servicesManger.ApprovalDelegationService.DeleteApprovalDelegationAsync(keys);
        //    if (deleteResult.Succeeded)
        //    {
        //        return Ok(deleteResult.Result);
        //    }
        //    return StatusCode(500, deleteResult.Errors);
        //}

        [HttpPost]
        public async Task<ActionResult> Update(ApprovalDelegationUpdateDto updateDto)
        {
            var updateResult = await this._servicesManger.ApprovalDelegationService.UpdateApprovalDelegationAsync(updateDto);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> BulkDelete(IEnumerable<EntityKeyValueDictionary> keysList)
        {
            var deleteResults = await this._servicesManger.ApprovalDelegationService.BulkDeleteApprovalDelegationsAsync(keysList);
            if (deleteResults.Succeeded)
            {
                return Ok(deleteResults.Result);
            }
            return StatusCode(500, deleteResults.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> ApprovalDLookUp(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.ApprovalDelegationService.GetApprovalDelegationApprovalDLookUpAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }
    }
}
