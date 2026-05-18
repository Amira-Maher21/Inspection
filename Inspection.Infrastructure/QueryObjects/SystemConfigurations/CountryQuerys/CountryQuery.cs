using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SystemConfigurations.CountryQuerys
{
    public class CountryQuery : QueryObjectBase<CountryDto>
    {
        public CountryQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CountryDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Sec.Country";
                string fields = "[Id], [Name], [Code], [Tenant_ID]";

                QueryStringData query =
                    await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await _dapper.QueryList<CountryDto>(
                    query.QueryString!,
                    query.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CountryDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<CountryDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CountryDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override async Task<ReturnBase<IEnumerable<CountryDto>>> Query(
            SqlQueryOptions queryOptions, string functionParameter)
        {
            return await Query(queryOptions);
        }

        public override async Task<ReturnBase<IEnumerable<CountryDto>>> Query(
            SqlQueryOptions queryOptions, object[] functionParameters)
        {
            return await Query(queryOptions);
        }
    }



    //    {
    //  "Sorts": [
    //    {
    //      "FieldName": "Id",
    //      "IsAscending": true,
    //      "IsNullFirst": false
    //    }
    //  ],
    //  "Skip": 0,
    //  "Take": 10,
    //  "GetTotal": true,
    //  "Filters": []
    //}


}
