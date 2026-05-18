using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.UserNotificationManagement;
using Inspection.Domain.Models.UserNotificationManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.UserNotificationManagement
{
    public interface IUserNotificationsService : IAccountServiceBase
    {
        Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> GetUserNotificationsIndexAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<UserNotificationsUpdateDto>> GetUserNotificationsEntityForUpdate(EntityKeyValueDictionary keys);

        Task<ReturnBase<UserNotificationsInsertDto>> InsertUserNotificationsAsync(UserNotificationsInsertDto insertDto);

        Task<ReturnBase<UserNotificationsUpdateDto>> UpdateUserNotificationsAsync(UserNotificationsUpdateDto updateDto);

        Task<ReturnBase<UserNotificationsInsertDto>> SendNotification(UserNotificationsInsertDto userNotificationsInsertDto);

        Task<ReturnBase> NotificationsRead(User_Notification[] notifications);
        Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> NotificationsNumber(UserNotificationsHelperDto userNotificationsHelperDto);

        Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteUserNotificationsAsync(IEnumerable<EntityKeyValueDictionary> keysList);
    }
}
