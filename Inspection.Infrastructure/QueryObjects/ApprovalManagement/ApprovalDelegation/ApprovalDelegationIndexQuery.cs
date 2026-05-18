using Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.ApprovalManagement.ApprovalDelegation
{
    internal class ApprovalDelegationIndexQuery : QueryObjectBase<ApprovalDelegationIndexItemDto>
    {
        public ApprovalDelegationIndexQuery(ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null) :
            base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ApprovalDelegationIndexItemDto>>> Query(SqlQueryOptions queryOptions)
        {
            string tableName = "[Sec].[Approval_Delegation]";
            string fields = "ID,IDScrAproval,User_ID,User_ID_Delegated,To_Date";
            bool ignoreFiscalYear = true;
            var queryData = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);
            var queryResult = await _dapper.QueryList<ApprovalDelegationIndexItemDto>(queryData.QueryString!, queryData.Parameters!.ToDictionary());
            return queryResult;


        }
        public override Task<ReturnBase<IEnumerable<ApprovalDelegationIndexItemDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ApprovalDelegationIndexItemDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
