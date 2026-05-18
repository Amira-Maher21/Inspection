using AutoMapper;
using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.UserNotificationManagement;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.UserNotificationManagement;
using Inspection.Application.Contracts.Repositories.Query.UserNotificationManagement;
using Inspection.Application.Contracts.Services.UserNotificationManagement;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.UserNotificationManagement;
using Microsoft.Extensions.Configuration;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.UserNotificationManagement
{
    internal class UserNotificationsService : AccountsServiceBase, IUserNotificationsService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public UserNotificationsService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, IConfiguration configuration, HttpClient httpClient) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<ReturnBase<UserNotificationsUpdateDto>> GetUserNotificationsEntityForUpdate(EntityKeyValueDictionary keys)
        {
            var findResult = await this._commands.GetEntityAsync(keys);
            if (findResult.Succeeded)
            {
                var mappingResult = this._mapper.Map<UserNotificationsUpdateDto>(findResult.Result);
                return ReturnBase<UserNotificationsUpdateDto>.Success(mappingResult);
            }
            else
            {
                return ReturnBase<UserNotificationsUpdateDto>.Fail(findResult.Errors);
            }
        }

        public async Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> GetUserNotificationsIndexAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.UserNotifications.GetUserNotificationsIndexAsync(queryOptions);
            return result;
        }

        public async Task<ReturnBase<UserNotificationsInsertDto>> InsertUserNotificationsAsync(UserNotificationsInsertDto insertDto)
        {
            try
            {
                var entity = this._mapper.Map<User_Notification>(insertDto);
                var insertResult = await this._commands.InsertAsync(entity);
                if (insertResult.Succeeded)
                {
                    var saveResult = await this._accountUoW.SaveAsync();
                    if (saveResult.Succeeded)
                    {
                        var insertedEntity = this._mapper.Map<UserNotificationsInsertDto>(insertResult.Result);
                        return ReturnBase<UserNotificationsInsertDto>.Success(insertedEntity);
                    }
                    return ReturnBase<UserNotificationsInsertDto>.Fail(saveResult.Errors);
                }
                return ReturnBase<UserNotificationsInsertDto>.Fail(insertResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<UserNotificationsInsertDto>.Fail(ex, this._exceptionManager);
            }
        }

        public async Task<ReturnBase<UserNotificationsUpdateDto>> UpdateUserNotificationsAsync(UserNotificationsUpdateDto updateDto)
        {
            try
            {
                var entity = this._mapper.Map<User_Notification>(updateDto);
                var updateResult = await this._commands.UpdateAsync(entity);
                if (updateResult.Succeeded)
                {
                    var saveResult = await this._accountUoW.SaveAsync();
                    if (saveResult.Succeeded)
                    {
                        var updatedEntity = this._mapper.Map<UserNotificationsUpdateDto>(updateResult.Result);
                        return ReturnBase<UserNotificationsUpdateDto>.Success(updatedEntity);
                    }
                    return ReturnBase<UserNotificationsUpdateDto>.Fail(saveResult.Errors);
                }
                return ReturnBase<UserNotificationsUpdateDto>.Fail(updateResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<UserNotificationsUpdateDto>.Fail(ex, this._exceptionManager);
            }
        }

        public async Task<ReturnBase<UserNotificationsInsertDto>> SendNotification(UserNotificationsInsertDto userNotificationsInsertDto)
        {
            UserNotificationsInsertDto insertDto = new UserNotificationsInsertDto();
            insertDto.User_CodeId = userNotificationsInsertDto.User_CodeId;
            insertDto.Screen_ID = userNotificationsInsertDto.Screen_ID;
            insertDto.NotificationSubject = userNotificationsInsertDto.NotificationSubject;
            insertDto.Descrp = userNotificationsInsertDto.Descrp;
            insertDto.Unread = true;
            insertDto.Date = DateTime.Now;
            insertDto.Deleted = false;

            try
            {
                var entity = this._mapper.Map<User_Notification>(insertDto);
                var insertResult = await this._commands.InsertAsync(entity);
                if (insertResult.Succeeded)
                {
                    var saveResult = await this._accountUoW.SaveAsync();
                    if (saveResult.Succeeded)
                    {
                        var insertedEntity = this._mapper.Map<UserNotificationsInsertDto>(insertResult.Result);
                        return ReturnBase<UserNotificationsInsertDto>.Success(insertedEntity);
                    }
                    return ReturnBase<UserNotificationsInsertDto>.Fail(saveResult.Errors);
                }
                return ReturnBase<UserNotificationsInsertDto>.Fail(insertResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<UserNotificationsInsertDto>.Fail(ex, this._exceptionManager);
            }
        }

        public void PushNotification(string Message, string TagMsg, string UserID)
        {
            NewNotificationHub.HubContext.Clients.User(UserID).SendNotification(Message, TagMsg);
        }

        public async Task<ReturnBase> NotificationsRead(User_Notification[] notifications)
        {
            try
            {
                foreach (var i in notifications)
                {
                    var keys = new EntityKeyValueDictionary { new KeyValuePair<string, object>("ID", i.ID) };
                    var entityUpdResult = await GetUserNotificationsEntityForUpdate(keys);
                    if (entityUpdResult.Succeeded)
                    {
                        var updResult = await UpdateUserNotificationsAsync(entityUpdResult.Result);
                        if (updResult.Succeeded)
                        {
                            continue;
                        }
                        else
                        {
                            return ReturnBase.Fail(updResult.Errors);
                        }
                    }
                    else
                    {
                        return ReturnBase.Fail(entityUpdResult.Errors);
                    }
                }
                return ReturnBase.Success();

            }
            catch (Exception ex)
            {
                return ReturnBase.Fail(ex, this._exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> NotificationsNumber(UserNotificationsHelperDto userNotificationsHelperDto)
        {
            userNotificationsHelperDto.queryOptions.Filters = new List<string[]>
            {
                new[] { "Unread", "=", "1" },
                new[] { "User_CodeId", "=", userNotificationsHelperDto.userNotificationsIndexItemDto.User_CodeId?.ToString() ?? string.Empty }
            };
            var result = await this._queriesManager.UserNotifications.GetUserNotificationsIndexAsync(userNotificationsHelperDto.queryOptions);
            return result;
        }

        public async Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteUserNotificationsAsync(IEnumerable<EntityKeyValueDictionary> keysList)
        {
            try
            {
                var deleteResult = await this._commands.BulkDeleteAsync(keysList, this._accountUoW.SaveAsync);
                if (deleteResult.Succeeded)
                {
                    var results = deleteResult.Result.Select(x => new DeleteResultDto
                    {
                        Deleted = x.Succeeded,
                        Errors = x.Errors
                    });

                    return ReturnBase<IEnumerable<DeleteResultDto>>.Success(results);
                }

                var failedResults = keysList.Select(x => new DeleteResultDto
                {
                    Deleted = false,
                    Errors = deleteResult.Errors
                });

                return ReturnBase<IEnumerable<DeleteResultDto>>.Fail(deleteResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DeleteResultDto>>.Fail(ex, this._exceptionManager);
            }
        }

        private IUserNotificationsCommandRepository _commands
        {
            get { return this._accountUoW.UserNotifications; }
        }

        private IUserNotificationsQueryRepository _queries
        {
            get { return this._queriesManager.UserNotifications; }
        }
    }
}
