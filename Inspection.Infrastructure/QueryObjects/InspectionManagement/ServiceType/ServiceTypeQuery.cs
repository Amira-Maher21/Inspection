using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
using Inspection.Infrastructure.QueryObjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

internal class ServiceTypeQuery : QueryObjectBase<ServiceTypeDtoByInclude>
{
    public ServiceTypeQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
    {
    }
    public override async Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> Query(SqlQueryOptions queryOptions)
    {

        try
        {
            string baseTable = "Inspection.ServiceType";
            string baseAlias = "R";

            var selectFields = new List<string>

            {
            "R.Id",
            "R.Name",
            "R.Description",
            "R.Tenant_ID"

        };

            //    var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
            //{
            //    //("LEFT JOIN", "[Customer] C", "C", "C.Id = R.CustomerId"),
            //    //("LEFT JOIN", "[Location] L", "L", "L.Id = R.LocationId"),
            //    //("LEFT JOIN", "[CustomerProject] P", "P", "P.Id = R.CustomerProjectId"),
            //    //("LEFT JOIN", "[ServiceTypes] S", "S", "S.Id = R.ServiceTypeId")
            //};

            //    var sb = new StringBuilder();
            //    sb.AppendLine($"SELECT {string.Join(", ", selectFields)}");
            //    sb.AppendLine($"FROM {baseTable} {baseAlias}");

            //    foreach (var join in joins)
            //        sb.AppendLine($"{join.JoinType} {join.Table} ON {join.Condition}");

            //    bool hasOrder = false;
            //    if (queryOptions?.Sorts != null && queryOptions.Sorts.Any())
            //    {
            //        var orders = queryOptions.Sorts
            //            .Select(s => $"{s.FieldName} {(s.IsAscending.HasValue && s.IsAscending.Value ? "ASC" : "DESC")}");
            //        sb.AppendLine("ORDER BY " + string.Join(", ", orders));
            //        hasOrder = true;
            //    }
            //    else
            //    {
            //        sb.AppendLine($"ORDER BY {baseAlias}.Id DESC");
            //        hasOrder = true;
            //    }


            //    string sql = sb.ToString();

            //    var result = await _dapper.QueryList<ServiceTypeDtoByInclude>(sql);

            //    if (!result.Succeeded)
            //        return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Fail(result.Errors);

            //    var list = base.ApplyFilters(result.Result, queryOptions);
            //    return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Success(list);
            var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, /*joins,*/ queryOptions);

            var result = await _dapper.QueryList<ServiceTypeDtoByInclude>(sql);

            if (!result.Succeeded)
                return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Fail(result.Errors);

            var list = base.ApplyFilters(result.Result, queryOptions);
            return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Success(list);
        }
        catch (Exception ex)
        {
            return ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>.Fail(ex, _exceptionManager);
        }
    }

    //public override async Task<ReturnBase<IEnumerable<ServiceTypeDto>>> Query(SqlQueryOptions queryOptions)
    //{
    //    try
    //    {

    //        string tableName = "ServiceTypes";
    //        string fields = "[Id], [Name], [Description] ,[Tenant_ID]";
    //        QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

    //        var result = await this._dapper.QueryList<ServiceTypeDto>(query.QueryString!, query.Parameters!.ToDictionary());
    //        if (!result.Succeeded)
    //            return ReturnBase<IEnumerable<ServiceTypeDto>>.Fail(result.Errors);

    //        return ReturnBase<IEnumerable<ServiceTypeDto>>.Success(result.Result);
    //    }
    //    catch (Exception ex)
    //    {
    //        return ReturnBase<IEnumerable<ServiceTypeDto>>.Fail(ex, _exceptionManager);
    //    }
    //}

    public override Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
    {
        throw new NotImplementedException();
    }
    public override Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
    {
        throw new NotImplementedException();
    }
}