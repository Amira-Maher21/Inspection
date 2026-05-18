using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Sample.CurrencyExchangeRate
{
    internal class SCurrencyExchangeRateListQuery : BaseQueryObject<SCurrencyExchangeRateListItemDto>
    {
        public SCurrencyExchangeRateListQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SCurrencyExchangeRateListItemDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.CurrencyExchangeRateHeader";
                var selectFields = new[]
                {
                "Id",
                "EffectiveDate",
                "Description",
                "IsActive"
            };

                var joinTableName = "Accounting.Currency";
                var joinSelectFields = "Name BaseCurrencyName";
                var joinField = "BaseCurrencyId Id";
                var joinTable = new JoinTable(joinTableName, joinSelectFields, joinField);


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { joinTable },
                    queryOptions);

                var queryResult = await _dapper.QueryList<SCurrencyExchangeRateListItemDto>(queryData.QueryString!, queryData.Parameters!.ToDictionary());


                return queryResult;
            }

            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SCurrencyExchangeRateListItemDto>>.Fail(ex, _exceptionManager);
            }

        }

        public override Task<ReturnBase<IEnumerable<SCurrencyExchangeRateListItemDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}