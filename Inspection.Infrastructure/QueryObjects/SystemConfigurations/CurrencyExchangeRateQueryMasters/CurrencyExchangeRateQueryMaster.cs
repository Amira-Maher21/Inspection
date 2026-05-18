using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.DetailTableDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SystemConfigurations.CurrencyExchangeRateQueryMasters
{
    internal class CurrencyExchangeRateQueryMaster
        : QueryObjectBase<CurrencyExchangeRateReturnSearchDto>
    {
        public CurrencyExchangeRateQueryMaster(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Query(
     SqlQueryOptions queryOptions)
        {
            try
            {
                // ================= MASTER + JOIN =================
                string tableName = "Sec.CurrencyExchangRate";

                var selectFields = new[]
                {
            "Id",
            "CurrencyId",
            "CompanyId",
            "EffectiveDate",
            "Description",
            "IsActive",
            "In_User",
            "In_Date",
            "Mod_User",
            "Mod_Date"
        };

                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id"
                );

                var masterQueryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { currencyJoin },
                    queryOptions);

                var masterResult =
                    await _dapper.QueryList<CurrencyExchangeRateReturnSearchDto>(
                        masterQueryData.QueryString!,
                        masterQueryData.Parameters!.ToDictionary());

                if (!masterResult.Succeeded)
                    return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>
                        .Fail(masterResult.Errors);

                var masters = masterResult.Result.ToList();

                if (!masters.Any())
                    return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>
                        .Success(masters);

                // ================= DETAILS =================
                string detailsSql = @"
            SELECT
                CurrencyExchangRateId,
                CurrencyId,
                Rate,
                In_User,
                In_Date,
                Mod_User,
                Mod_Date
            FROM Sec.DetailTable
            WHERE CurrencyExchangRateId IN @MasterIds
        ";

                var parameters = new Dictionary<string, object>
        {
            { "MasterIds", masters.Select(x => x.Id).ToArray() }
        };

                var detailsResult =
                    await _dapper.QueryList<DetailTableDto>(detailsSql, parameters);

                if (!detailsResult.Succeeded)
                    return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>
                        .Fail(detailsResult.Errors);

                var detailsLookup = detailsResult.Result
                    .GroupBy(d => d.CurrencyExchangRateId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var master in masters)
                {
                    if (detailsLookup.TryGetValue(master.Id, out var details))
                        master.Details = details;
                }

                return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>
                    .Success(masters);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }


        //public override async Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        //{
        //    try
        //    {
        //        var tableName = "Sec.CurrencyExchangRate";
        //        var selectFields = new[]
        //        {
        //    "Id",
        //    "CurrencyId",
        //    "CompanyId",
        //    "EffectiveDate",
        //    "Description",
        //    "IsActive",
        //    "In_User",
        //    "In_Date",
        //    "Mod_User",
        //    "Mod_Date"
        //};

        //        var joinTableName = "Sec.Currency";
        //        var joinSelectFields = "Code CurrencyCode, Name CurrencyName";
        //        var joinField = "CurrencyId Id";
        //        var joinTable = new NDS.Shared.Application.DataQuery.JoinTable(joinTableName, joinSelectFields, joinField);


        //        var queryData = await _queryBuilder.GetQueryStringDataAsync(
        //            tableName,
        //            string.Join(", ", selectFields),
        //            new List<JoinTable> { joinTable },
        //            queryOptions);

        //        var queryResult = await _dapper.QueryList<CurrencyExchangeRateReturnSearchDto>(queryData.QueryString!, queryData.Parameters!.ToDictionary());

        //        return queryResult;
        //    }

        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>.Fail(ex, _exceptionManager);
        //    }

        //}
        public override Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
