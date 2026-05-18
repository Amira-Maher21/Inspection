using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.CustomerProject
{
    internal class CustomerProjectQuery : QueryObjectBase<CustomerProjectDtoByInclude>
    {
        public CustomerProjectQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.CustomerProject";
                string baseAlias = "P";

                var selectFields = new List<string>
            {
            "P.Id",
            "P.CustomerId",
            "P.ProjectCode",
            "P.ProjectName",
            "P.Location",
            "P.StreetName",
            "P.BuildingNumber",
            "P.District",
            "P.City",
            "P.PostalCode",
            "P.AdditionalNumber",
            "P.GPSLatitude",
            "P.GPSLongitude",
            "P.Notes",

            "CR.Name as CustomerName",
        };


                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("LEFT JOIN", "[Accounting].[Customer] CR", "CR", "CR.Id = P.CustomerId")
        };

                var sb = new StringBuilder();
                sb.AppendLine($"SELECT {string.Join(", ", selectFields)}");
                sb.AppendLine($"FROM {baseTable} {baseAlias}");

                foreach (var join in joins)
                    sb.AppendLine($"{join.JoinType} {join.Table} ON {join.Condition}");

                bool hasOrder = false;
                if (queryOptions?.Sorts != null && queryOptions.Sorts.Any())
                {
                    var orders = queryOptions.Sorts
                        .Select(s => $"{s.FieldName} {(s.IsAscending.HasValue && s.IsAscending.Value ? "ASC" : "DESC")}");
                    sb.AppendLine("ORDER BY " + string.Join(", ", orders));
                    hasOrder = true;
                }
                else
                {
                    sb.AppendLine($"ORDER BY {baseAlias}.Id DESC");
                    hasOrder = true;
                }


                string sql = sb.ToString();

                var result = await _dapper.QueryList<CustomerProjectDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        //public override async Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        //{
        //    try
        //    {

        //        string tableName = "CustomerProject";
        //        string fields = "[Id], [Name], [CompanyId], [CustomerId], [LocationId], [CustomerProjectDate],  [Tenant_ID]";
        //        QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

        //        var result = await this._dapper.QueryList<CustomerProjectDto>(query.QueryString!, query.Parameters.ToDictionary());
        //        if (!result.Succeeded)
        //            return ReturnBase<IEnumerable<CustomerProjectDto>>.Fail(result.Errors);

        //        return ReturnBase<IEnumerable<CustomerProjectDto>>.Success(result.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<CustomerProjectDto>>.Fail(ex, _exceptionManager);
        //    }
        //}

        public override Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}