using Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.ApprovalManagement.ApprovalDelegation
{
    internal class ApprovalDelegationApprovalDLookUpQuery : QueryObjectBase<ApprovalDelegationApprovalDLookUpDto>
    {
        public ApprovalDelegationApprovalDLookUpQuery(ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null) :
            base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ApprovalDelegationApprovalDLookUpDto>>> Query(SqlQueryOptions queryOptions)
        {
            string sql = "SELECT IDScrAproval,Approval_title FROM Sec.Approval_d WHERE User_ID = @UserName";
            var parameters = new Dictionary<string, object>
            {
                //{ "Tenant_ID", _tenantResolver.GetCommonUserData().TenantName },
                { "UserName", _tenantResolver.GetCommonUserData().UserName }
            };

            var queryResult = await _dapper.QueryList<ApprovalDelegationApprovalDLookUpDto>(sql, parameters);
            return queryResult;
        }
        public override Task<ReturnBase<IEnumerable<ApprovalDelegationApprovalDLookUpDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ApprovalDelegationApprovalDLookUpDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
