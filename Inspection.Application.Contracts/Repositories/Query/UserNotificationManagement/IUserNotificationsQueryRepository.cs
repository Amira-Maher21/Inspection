using Inspection.Application.Contracts.Dto.UserNotificationManagement;
using Inspection.Domain.Models.UserNotificationManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.UserNotificationManagement
{
    public interface IUserNotificationsQueryRepository : IQueryRepository<User_Notification>
    {
        Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> GetUserNotificationsIndexAsync(SqlQueryOptions queryOptions);

    }
}
