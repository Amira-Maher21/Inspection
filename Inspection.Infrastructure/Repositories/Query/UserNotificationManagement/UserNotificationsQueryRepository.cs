using Inspection.Application.Contracts.Dto.UserNotificationManagement;
using Inspection.Application.Contracts.Repositories.Query.UserNotificationManagement;
using Inspection.Domain.Models.UserNotificationManagement;
using Inspection.Infrastructure.QueryObjects.UserNotificationManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.UserNotificationManagement
{
    internal class UserNotificationsQueryRepository : QueryRepositoryBase<User_Notification>, IUserNotificationsQueryRepository
    {
        public UserNotificationsQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> GetUserNotificationsIndexAsync(SqlQueryOptions queryOptions)
        {
            UserNotificationsIndexQuery indexQuery = new UserNotificationsIndexQuery(this._queryBuilder, this._dapper, this._tenantResolver, this._exceptionManager);
            return await base.Query(indexQuery, queryOptions);
        }
    }
}
