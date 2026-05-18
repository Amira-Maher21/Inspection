using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionChecklistMoreInformationDetails
{

    internal class InspectionChecklistMoreInformationDetailQuery : QueryObjectBase<InspectionChecklistMoreInformationDetailDtoByInclude>
    {
        public InspectionChecklistMoreInformationDetailQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.InspectionChecklistMoreInformationDetail";
                string baseAlias = "EqT";

                var selectFields = new List<string>
                {
                    "KeyName",
                    "KeyValue",
                    "InspectionChecklistMoreInformationId",
                    "Tenant_ID"

                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>();

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<InspectionChecklistMoreInformationDetailDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}