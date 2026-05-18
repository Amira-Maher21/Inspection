using Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.ApprovalManagement
{
    internal class ApprovalUser_CodeMLookUpQuery : QueryObjectBase<ApprovalUser_CodeMLookUpDto>
    {
        public ApprovalUser_CodeMLookUpQuery(ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null) :
            base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public async override Task<ReturnBase<IEnumerable<ApprovalUser_CodeMLookUpDto>>> Query(SqlQueryOptions queryOptions)
        {
            string sql = "SELECT * FROM [Sec].[User_Code] where Tenant_ID = (@Tenant_ID)";

            var parameters = new Dictionary<string, object>
            {
                { "Tenant_ID", _tenantResolver.GetCommonUserData().TenantName }
            };

            var queryResult = await _dapper.QueryList<ApprovalUser_CodeMLookUpDto>(sql, parameters);
            return queryResult;
        }

        public override Task<ReturnBase<IEnumerable<ApprovalUser_CodeMLookUpDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ApprovalUser_CodeMLookUpDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
