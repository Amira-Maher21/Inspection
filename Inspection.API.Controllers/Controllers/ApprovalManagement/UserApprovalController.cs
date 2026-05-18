//using Inspection.API.Controllers.AppControllersBase;
//using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.Application.DataQuery;
//using NDS.Shared.Application.SharedModels;

//namespace Inspection.API.Controllers.Controllers.ApprovalManagement
//{
//    [Route("api/userapproval/[action]")]
//    public class UserApprovalController : AccountsControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public UserApprovalController(IAccountsServicesManger servicesManger)
//        {
//            this._servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<ActionResult> Index(SqlQueryOptions queryOptions)
//        {
//            var getIndexResult = await this._servicesManger.UserApprovalService.GetUserApprovalIndexAsync(queryOptions);
//            if (getIndexResult.Succeeded)
//            {
//                return Ok(getIndexResult.Result);
//            }
//            return StatusCode(500, getIndexResult.Errors);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Insert(UserApprovalInsertDto insertDto)
//        {
//            var insertResult = await this._servicesManger.UserApprovalService.InsertUserApprovalAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Entity(EntityKeyValueDictionary keys)
//        {
//            var getEntityResult = await this._servicesManger.UserApprovalService.GetUserApprovalEntityForUpdate(keys);
//            if (getEntityResult.Succeeded)
//            {
//                return Ok(getEntityResult.Result);
//            }
//            return StatusCode(500, getEntityResult.Errors);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Update(UserApprovalUpdateDto updateDto)
//        {
//            var updateResult = await this._servicesManger.UserApprovalService.UpdateUserApprovalAsync(updateDto);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }

//        [HttpPost]
//        public async Task<ActionResult> BulkDelete(IEnumerable<EntityKeyValueDictionary> keysList)
//        {
//            var deleteResults = await this._servicesManger.UserApprovalService.BulkDeleteUserApprovalAsync(keysList);
//            if (deleteResults.Succeeded)
//            {
//                return Ok(deleteResults.Result);
//            }
//            return StatusCode(500, deleteResults.Errors);
//        }
//    }
//}
