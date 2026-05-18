using Inspection.Application.Contracts.Dto.TestTableMasters;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.TestTableMasters
{

    public class TestTableMasterQuery : QueryObjectBase<TestTableMasterDtoByInclude>
    {
        public TestTableMasterQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.TestTableMaster";
                string baseAlias = "R";

                var selectFields = new List<string>
            {
            "R.Name"

                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
                {

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

                var result = await _dapper.QueryList<TestTableMasterDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
    }
}