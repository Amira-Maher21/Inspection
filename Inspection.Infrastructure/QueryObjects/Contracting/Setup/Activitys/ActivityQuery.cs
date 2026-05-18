using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Contracting.Setup.Activitys
{
    internal class ActivityQuery : QueryObjectBase<ActivityReturnSearchDto>
    {
        public ActivityQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ActivityReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Contracting.Activity";

                string fields =
                    "[Id],[Tenant_ID],[CompanyId],[ActivityCode],[ActivityName]," +
                    "[OperationId],[WBSId],[StartDate],[EndDate]," +
                    "[PlannedCost],[ProgressPercent],[In_User],[In_Date],[Mod_User],[Mod_Date]";


                var joins = new List<JoinTable>
                {
                    new JoinTable("Sec.Operation",
                        "Code OperationCode,Name OperationName",
                        "OperationId Id"),

                    new JoinTable("Contracting.WBS",
                        "WBSCode ,WBSName ",
                        "WBSId Id")




                };

                QueryStringData query =
                    await _queryBuilder.GetQueryStringDataAsync(tableName, fields, joins, queryOptions);

                var result = await _dapper.QueryList<ActivityReturnSearchDto>(
                    query.QueryString!,
                    query.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ActivityReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ActivityReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ActivityReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}