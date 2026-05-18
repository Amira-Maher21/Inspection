using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs;
using Inspection.Infrastructure.Migrations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SystemConfigurations.CityQueries
{
    internal class CityQuery : QueryObjectBase<CitySearchReturnDto>
    {
        public CityQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        //public override async Task<ReturnBase<IEnumerable<CityDto>>> Query(SqlQueryOptions queryOptions)
        //{
        //    try
        //    {
        //        string tableName = "City";
        //        string fields = "[Id], [Name],[Code], [Tenant_ID]";
        //        QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

        //        var result = await this._dapper.QueryList<CityDto>(query.QueryString!, query.Parameters!.ToDictionary());
        //        if (!result.Succeeded)
        //            return ReturnBase<IEnumerable<CityDto>>.Fail(result.Errors);

        //        return ReturnBase<IEnumerable<CityDto>>.Success(result.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<CityDto>>.Fail(ex, _exceptionManager);
        //    }
        //}

        public override async Task<ReturnBase<IEnumerable<CitySearchReturnDto>>> Query(
    SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Sec.City";

                var selectFields = new[]
                {
                 "Id",
                 "Code",
                 "Name",
                 "Tenant_ID",
                 "CountryId"
                 };

                var joinTableName = "Sec.Country";
                var joinSelectFields = "Code CountryCode, Name CountryName";
                var joinField = "CountryId Id";

                var joinTable = new JoinTable(
                    joinTableName,
                    joinSelectFields,
                    joinField
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { joinTable },
                    queryOptions
                );

                var queryResult =
                    await _dapper.QueryList<CitySearchReturnDto>(
                        queryData.QueryString!,
                        queryData.Parameters!.ToDictionary()
                    );

                return queryResult;
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CitySearchReturnDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<CitySearchReturnDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CitySearchReturnDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}