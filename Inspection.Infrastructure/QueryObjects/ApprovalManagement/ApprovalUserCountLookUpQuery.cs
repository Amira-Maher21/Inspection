using Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.ApprovalManagement
{
    internal class ApprovalUserCountLookUpQuery : QueryObjectBase<ApprovalUserCountLookUpDto>
    {
        public ApprovalUserCountLookUpQuery(ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null) :
            base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public async override Task<ReturnBase<IEnumerable<ApprovalUserCountLookUpDto>>> Query(SqlQueryOptions queryOptions)
        {
            string sql = "SELECT d.Screen_ID, u.ScreenName, d.User_ID_Count FROM (SELECT sa.Screen_ID, COUNT(s.User_ID) AS User_ID_Count FROM Sec.Approval AS sa INNER JOIN Sec.Approval_d AS s ON sa.ID = s.IDScrAproval WHERE s.User_ID = @UserName GROUP BY sa.Screen_ID) AS d INNER JOIN Syst.User_Approval AS u ON d.Screen_ID = u.Screen_ID GROUP BY d.Screen_ID, u.ScreenName, d.User_ID_Count";

            var parameters = new Dictionary<string, object>
            {
                { "UserName", _tenantResolver.GetCommonUserData().UserName }
            };

            var queryResult = await _dapper.QueryList<ApprovalUserCountLookUpDto>(sql, parameters);
            return queryResult;
        }

        public override Task<ReturnBase<IEnumerable<ApprovalUserCountLookUpDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ApprovalUserCountLookUpDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}