using Inspection.API.Controllers.AppControllersBase;
using Inspection.Application.Contracts.Dto.UserNotificationManagement;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Models.UserNotificationManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;

namespace Inspection.API.Controllers.Controllers.UserNotificationManagement
{
    [Route("api/usernotification/[action]")]
    public class UserNotificationsController : AccountsControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public UserNotificationsController(IAccountsServicesManger servicesManger)
        {
            this._servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<ActionResult> Index(SqlQueryOptions queryOptions)
        {
            var getIndexResult = await this._servicesManger.UserNotificationsService.GetUserNotificationsIndexAsync(queryOptions);
            if (getIndexResult.Succeeded)
            {
                return Ok(getIndexResult.Result);
            }
            return StatusCode(500, getIndexResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(UserNotificationsInsertDto insertDto)
        {
            var insertResult = await this._servicesManger.UserNotificationsService.InsertUserNotificationsAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Entity(EntityKeyValueDictionary keys)
        {
            var getEntityResult = await this._servicesManger.UserNotificationsService.GetUserNotificationsEntityForUpdate(keys);
            if (getEntityResult.Succeeded)
            {
                return Ok(getEntityResult.Result);
            }
            return StatusCode(500, getEntityResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UserNotificationsUpdateDto updateDto)
        {
            var updateResult = await this._servicesManger.UserNotificationsService.UpdateUserNotificationsAsync(updateDto);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> SendNotification(UserNotificationsInsertDto userNotificationsInsertDto)
        {
            var sendResult = await this._servicesManger.UserNotificationsService.SendNotification(userNotificationsInsertDto);
            if (sendResult.Succeeded)
            {
                return Ok(sendResult.Result);
            }
            return StatusCode(500, sendResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> NotificationsRead([FromBody] User_Notification[] notifications)
        {
            var readResult = await this._servicesManger.UserNotificationsService.NotificationsRead(notifications);
            if (readResult.Succeeded)
            {
                return Ok();
            }
            return StatusCode(500, readResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> NotificationsNumber(UserNotificationsHelperDto userNotificationsHelperDto)
        {
            var notificationsNumberResult = await this._servicesManger.UserNotificationsService.NotificationsNumber(userNotificationsHelperDto);
            if (notificationsNumberResult.Succeeded)
            {
                return Ok(notificationsNumberResult.Result.Count());
            }
            return StatusCode(500, notificationsNumberResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> BulkDelete(IEnumerable<EntityKeyValueDictionary> keysList)
        {
            var deleteResults = await this._servicesManger.UserNotificationsService.BulkDeleteUserNotificationsAsync(keysList);
            if (deleteResults.Succeeded)
            {
                return Ok(deleteResults.Result);
            }
            return StatusCode(500, deleteResults.Errors);
        }
    }
}
