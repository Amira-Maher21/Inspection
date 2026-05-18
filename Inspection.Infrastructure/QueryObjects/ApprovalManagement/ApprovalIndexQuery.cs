using Inspection.Application.Contracts.Dto.ApprovalManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.ApprovalManagement
{
    internal class ApprovalIndexQuery : QueryObjectBase<ApprovalDto>
    {
        public ApprovalIndexQuery(ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? ScreenCodeDApproval = null) :
            base(queryBuilder, dapper, tenantResolver, exceptionManager, ScreenCodeDApproval)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ApprovalDto>>> Query(SqlQueryOptions queryOptions)
        {
            string tableName = "Sec.Approval";
            string fields = "Tenant_ID, Id, ScreenId, CompanyId, Active, WorkFlowTitle";

            bool ignoreScreenCodeDApproval = true;
            var queryData = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);
            var queryResult = await _dapper.QueryList<ApprovalDto>(queryData.QueryString!, queryData.Parameters!.ToDictionary());
            return queryResult;
        }

        public override Task<ReturnBase<IEnumerable<ApprovalDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ApprovalDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
