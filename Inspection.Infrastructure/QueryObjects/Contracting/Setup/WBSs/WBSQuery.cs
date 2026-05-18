using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Contracting.Setup.WBSs
{
    public class WBSQuery : QueryObjectBase<WBSReturnSearchDto>
    {
        public WBSQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<WBSReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Contracting.WBS";

                string fields = "[Id],[Tenant_ID],[CompanyId],[WBSCode],[WBSName]," +
                                "[OperationId],[ParentWBSId],[LevelNo],[IsLeaf]," +
                                "[In_User],[In_Date],[Mod_User],[Mod_Date]";

                var joins = new List<JoinTable>
                {
                    new JoinTable("Sec.Operation",
                        "Code OperationCode,Name OperationName",
                        "OperationId Id"),

                   new JoinTable("Contracting.WBS",
                        "WBSCode ParentWBSCode,WBSName ParentWBSName",
                        "ParentWBSId  Id")
                };

                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(
                    tableName, fields, joins, queryOptions);

                var result = await _dapper.QueryList<WBSReturnSearchDto>(
                    query.QueryString!, query.Parameters!.ToDictionary());

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<WBSReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<WBSReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WBSReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<WBSReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<WBSReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}