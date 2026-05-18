using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inspection.InspectorCompetency
{
    public class InspectorCompetencyQuery : QueryObjectBase<InspectorCompetencyReturnSearchDto>
    {
        public InspectorCompetencyQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.InspectorCompetency";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "InspectorId",
                    "IssueDate",
                    "ExpiryDate",
                    "Notes",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
               };

                // Joins

                var inspectorCompetencyJoin = new JoinTable(
                    "Inspection.Inspector",
                    "Code InspectorCode, FirstName InspectorName",
                    "InspectorId Id"
                    );


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { inspectorCompetencyJoin },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<InspectorCompetencyReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}