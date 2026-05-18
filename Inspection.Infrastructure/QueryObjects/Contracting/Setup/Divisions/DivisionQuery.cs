using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Contracting.Setup.Divisions
{
    public class DivisionQuery : QueryObjectBase<DivisionReturnSearchDto>
    {
        public DivisionQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DivisionReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Contracting.Division";

                string fields = "[Id],[Tenant_ID],[CompanyId],[DivisionCode],[DivisionName]," +
                                "[ParentDivisionId],[IsLeaf]," +
                                "[In_User],[In_Date],[Mod_User],[Mod_Date]";

                var joins = new List<JoinTable>
                    {
                        new JoinTable(
                            "Contracting.Division",
                            "DivisionCode ParentDivisionCode, DivisionName ParentDivisionName",
                            "ParentDivisionId Id"
                        )
                    };

                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(
                    tableName, fields, joins, queryOptions);

                var result = await _dapper.QueryList<DivisionReturnSearchDto>(
                    query.QueryString!, query.Parameters!.ToDictionary());

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DivisionReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DivisionReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DivisionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DivisionReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<DivisionReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}