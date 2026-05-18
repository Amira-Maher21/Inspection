using Inspection.API.Controllers.AppControllersBase;
using Inspection.Application.Contracts.Dto.ApprovalManagement;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;

namespace Inspection.API.Controllers.Controllers.ApprovalManagement
{
    [Route("api/approval/[action]")]
    public class ApprovalController : AccountsControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ApprovalController(IAccountsServicesManger servicesManger)
        {
            this._servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<ActionResult> Search(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.ApprovalService.GetApprovalIndexAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApprovalInsertDto insertDto)
        {
            var insertResult = await this._servicesManger.ApprovalService.InsertApprovalAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.ApprovalService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Entity(EntityKeyValueDictionary keys)
        {
            var getEntityResult = await this._servicesManger.ApprovalService.GetApprovalEntityForUpdate(keys);
            if (getEntityResult.Succeeded)
            {
                return Ok(getEntityResult.Result);
            }
            return StatusCode(500, getEntityResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.ApprovalService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> BulkDelete(IEnumerable<EntityKeyValueDictionary> keysList)
        {
            var deleteResults = await this._servicesManger.ApprovalService.BulkDeleteApprovalAsync(keysList);
            if (deleteResults.Succeeded)
            {
                return Ok(deleteResults.Result);
            }
            return StatusCode(500, deleteResults.Errors);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ApprovalUpdateDto updateDto)
        {
            var updateResult = await this._servicesManger.ApprovalService.UpdateApprovalAsync(updateDto);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> LookUpApprovalHlpScrScreenCodedApproval(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.ApprovalService.GetApprovalHlpScrScreenCodedApprovalLookUpAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> LookUpApprovalUser_CodeM(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.ApprovalService.GetApprovalUser_CodeMLookUpAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }
        [HttpPost]
        public async Task<ActionResult> LookUpApprovalUser_CodeD(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.ApprovalService.GetApprovalUser_CodeDLookUpAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }
        [HttpPost]
        public async Task<ActionResult> LookUpApprovalUserCount(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.ApprovalService.GetApprovalUserCountLookUpAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }

        //[HttpPost]
        //public async Task<ActionResult> LookUpApprovalUser_CodeD(LookUpRequest request)
        //{
        //    var lookupData = await this._servicesManger.ApprovalService.GetApprovalUser_CodeDLookUpAsync(request.QueryOptions);

        //    if (lookupData.Succeeded)
        //    {
        //        var filteredLookup = this._servicesManger.ApprovalService.filterHlp(request, lookupData);

        //        return Ok(filteredLookup);
        //    }
        //    return StatusCode(500, lookupData.Errors);
        //}

        [HttpPost]
        public async Task<ActionResult> RequestApproval(RequestApprovalDto requestApprovalDto)
        {
            var requestApprovalResult = await this._servicesManger.ApprovalService.RequestApproval(requestApprovalDto);
            if (requestApprovalResult.Succeeded)
            {
                return Ok(requestApprovalResult.Result);
            }
            return StatusCode(500, requestApprovalResult.Errors);
        }

        [HttpPost]

        public async Task<ActionResult> DoApproval(DoApprovalDto doApprovalDto)
        {
            var doApprovalResult = await this._servicesManger.ApprovalService.DoApproval(doApprovalDto);
            if (doApprovalResult.Succeeded)
            {
                return Ok(doApprovalResult.Result);
            }
            return StatusCode(500, doApprovalResult.Errors);
        }
    }
}
