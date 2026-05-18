using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountingSystem
{
    public class DefaultAccountAssignmentQuery : QueryObjectBase<DefaultAccountAssignmentReturnSearchDto>
    {
        public DefaultAccountAssignmentQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.DefaultAccountAssignment";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "DefaultAccountGroupID",
                    "DefaultAccountTypeID",
                    "AccountID",
                    "CurrencyID",

                };

                // Joins
                var accountGroupJoin = new JoinTable(
                    "Accounting.DefaultAccountGroup",
                    "GroupCode, GroupName",
                     "DefaultAccountGroupID Id"
                );



                var accountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode, AccountName",
                    "AccountID Id"
                );


                var DefaultAccountTypeJoin = new JoinTable(
                "Accounting.DefaultAccountType",
                "Code  DefaultAccountTypeCode",
                "DefaultAccountTypeID Id"
            );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { accountGroupJoin, accountJoin, DefaultAccountTypeJoin },
                    queryOptions
                );

                var result = await _dapper.QueryList<DefaultAccountAssignmentReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
