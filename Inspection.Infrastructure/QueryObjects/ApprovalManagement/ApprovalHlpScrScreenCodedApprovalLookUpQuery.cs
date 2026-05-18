using Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.QueryObjects.ApprovalManagement
{
    internal class ApprovalHlpScrScreenCodedApprovalLookUpQuery : QueryObjectBase<ApprovalHlpScrScreenCodedApprovalLookUpDto>
    {
        public ApprovalHlpScrScreenCodedApprovalLookUpQuery(ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null) :
            base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ApprovalHlpScrScreenCodedApprovalLookUpDto>>> Query(SqlQueryOptions queryOptions, string tenant_ID)
        {
            string functionName = "[Hlp_Scr_Screen_Code_dApproval]";
            var parameters = new Dictionary<string, object>
            {
                { "@Tenant_ID", tenant_ID }
            };

            var queryResult = await _dapper.QueryList<ApprovalHlpScrScreenCodedApprovalLookUpDto>(functionName, parameters);
            return queryResult;
        }

        public async override Task<ReturnBase<IEnumerable<ApprovalHlpScrScreenCodedApprovalLookUpDto>>> Query(SqlQueryOptions queryOptions)
        {
            string sql = "SELECT * FROM [Hlp_Scr_Screen_Code_dApproval](@Tenant_ID)";
            var parameters = new Dictionary<string, object>
            {
                { "Tenant_ID", _tenantResolver.GetCommonUserData().TenantName }
            };

            var queryResult = await _dapper.QueryList<ApprovalHlpScrScreenCodedApprovalLookUpDto>(sql, parameters);
            return queryResult;
        }

        public override Task<ReturnBase<IEnumerable<ApprovalHlpScrScreenCodedApprovalLookUpDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
