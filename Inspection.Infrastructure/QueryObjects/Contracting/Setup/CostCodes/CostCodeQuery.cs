using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Contracting.Setup.CostCodes
{
    public class CostCodeQuery : QueryObjectBase<CostCodeReturnSearchDto>
    {
        public CostCodeQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CostCodeReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Contracting.CostCode";

                string fields = "[Id],[Tenant_ID],[CompanyId],[CostCodeValue],[CostCodeName]," +
                                "[DivisionId],[ParentCostCodeId],[IsLeaf]," +
                                "[In_User],[In_Date],[Mod_User],[Mod_Date]";

                var joins = new List<JoinTable>
                {
                    new JoinTable("Contracting.Division",
                        "DivisionCode, DivisionName",
                        "DivisionId Id"),

                    new JoinTable("Contracting.CostCode",
                        "CostCodeValue ParentCostCodeValue,CostCodeName ParentCostCodeName",
                        "ParentCostCodeId Id")
                };

                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(
                    tableName, fields, joins, queryOptions);

                var result = await _dapper.QueryList<CostCodeReturnSearchDto>(
                    query.QueryString!, query.Parameters!.ToDictionary());

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CostCodeReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<CostCodeReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CostCodeReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CostCodeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<CostCodeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}