using Inspection.Application.Contracts.Dto.UserNotificationManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.UserNotificationManagement
{
    internal class UserNotificationsIndexQuery : QueryObjectBase<UserNotificationsIndexItemDto>
    {
        public UserNotificationsIndexQuery(ISqlQueryBuilder queryBuilder,
           DapperDbContext dapper,
           ITenantResolver tenantResolver,
           IExceptionManager exceptionManager,
           string? CostCenterCode = null) :
           base(queryBuilder, dapper, tenantResolver, exceptionManager, CostCenterCode)
        {

        }

        public override async Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> Query(SqlQueryOptions queryOptions)
        {
            string tableName = "[Syst].[User_Notification]";
            string fields = "User_ID, Screen_ID, [Values], NotificationSubject, Descrp, Unread, Date, Deleted, Push_Error, Email_Error";

            bool ignoreCostCenterCode = true;
            var queryData = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);
            var queryResult = await _dapper.QueryList<UserNotificationsIndexItemDto>(queryData.QueryString!, queryData.Parameters!.ToDictionary());
            return queryResult;
        }

        public override Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<UserNotificationsIndexItemDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}