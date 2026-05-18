using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.CustomerLocation
{
    internal class CustomerLocationQuery : QueryObjectBase<CustomerLocationDtoByInclude>
    {
        public CustomerLocationQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.CustomerLocation";
                string baseAlias = "L";

                var selectFields = new List<string>
            {
            "L.Id",
            "L.Name",
            "L.CompanyId",
            "L.CustomerId",
            "L.Tenant_ID",

            "CR.Name AS CustomerName",
            "CM.Name AS CompanyName"

        };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("LEFT JOIN", "[Accounting].[Customer] CR", "CR", "CR.Id = L.CustomerId"),
            ("LEFT JOIN", "[Sec].[Company] CM", "CM", "CM.Id = L.CompanyId")
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

                var result = await _dapper.QueryList<CustomerLocationDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}