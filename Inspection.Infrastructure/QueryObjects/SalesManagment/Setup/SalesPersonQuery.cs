using Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SalesManagment.Setup
{
    internal class SalesPersonQuery : QueryObjectBase<SalesPersonSearchDto>
    {
        public SalesPersonQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SalesPersonSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Sales.SalesPerson";

                string fields =
                    "[Id], [Code], [Name], [Email], [Mobile], [Phone], " +
                    "[MaxDiscountPercent], [CanApproveQuotation], [TargetAmount], " +
                    "[HireDate], [SalesRole], [User_CodeID], [Tenant_ID] ";

                var joins = new List<JoinTable>
                {
                   new JoinTable(
                        "Sec.User_Code",
                        "User_Name",
                        "User_CodeId Id"
                    )
                };



                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<SalesPersonSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<SalesPersonSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<SalesPersonSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesPersonSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SalesPersonSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<SalesPersonSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}