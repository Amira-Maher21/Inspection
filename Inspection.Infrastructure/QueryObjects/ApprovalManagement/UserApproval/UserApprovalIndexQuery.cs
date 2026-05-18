using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.ApprovalManagement.UserApproval
{
    internal class UserApprovalIndexQuery : QueryObjectBase<UserApprovalIndexItemDto>
    {
        public UserApprovalIndexQuery(ISqlQueryBuilder queryBuilder,
           DapperDbContext dapper,
           ITenantResolver tenantResolver,
           IExceptionManager exceptionManager,
           string? CostCenterCode = null) :
           base(queryBuilder, dapper, tenantResolver, exceptionManager, CostCenterCode)
        {

        }

        public override async Task<ReturnBase<IEnumerable<UserApprovalIndexItemDto>>> Query(SqlQueryOptions queryOptions)
        {
            string tableName = "[Syst.User_Approval]";
            string fields = "id,Screen_ID,TableMasterName,Keys,[Values],ScreenName,Date,Descrp,RepFileName,Status,User_ID,User_ID_SentTo,Rejected_Reasons,Hold_Reasons,Returned_Reasons,Delegate_Reasons,Returned_User_ID,Delegate_User_ID,ReceivedDate,ActionDate,Confirm_No, In_User";

            bool ignoreCostCenterCode = true;
            var queryData = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);
            var queryResult = await _dapper.QueryList<UserApprovalIndexItemDto>(queryData.QueryString!, queryData.Parameters!.ToDictionary());
            return queryResult;
        }

        public override Task<ReturnBase<IEnumerable<UserApprovalIndexItemDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<UserApprovalIndexItemDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
