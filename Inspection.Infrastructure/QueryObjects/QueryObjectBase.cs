using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects
{
    public abstract class QueryObjectBase<TResult> : IQueryObject<TResult>
    {
        protected readonly ISqlQueryBuilder _queryBuilder;
        protected readonly DapperDbContext _dapper;
        protected readonly ITenantResolver _tenantResolver;
        protected readonly IExceptionManager _exceptionManager;
        protected string? _fiscalYear;

        protected QueryObjectBase(ISqlQueryBuilder queryBuilder,
                                    DapperDbContext dapper,
                                    ITenantResolver tenantResolver,
                                    IExceptionManager exceptionManager,
                                    string? fiscalYear = null)
        {
            _queryBuilder = queryBuilder;
            _dapper = dapper;
            _tenantResolver = tenantResolver;
            _exceptionManager = exceptionManager;
            _fiscalYear = fiscalYear;
        }

        public abstract Task<ReturnBase<IEnumerable<TResult>>> Query(SqlQueryOptions queryOptions);
        public abstract Task<ReturnBase<IEnumerable<TResult>>> Query(SqlQueryOptions queryOptions, string functionParameter);
        public abstract Task<ReturnBase<IEnumerable<TResult>>> Query(SqlQueryOptions queryOptions, object[] functionParameters);

        public string ApplyJoinQuary(string baseTable, string baseAlias, List<string> selectFields, SqlQueryOptions queryOptions)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"SELECT {string.Join(", ", selectFields)}");
            sb.AppendLine($"FROM {baseTable} {baseAlias}");



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
                sb.AppendLine($"ORDER BY {baseAlias}.Id ASC");
                hasOrder = true;
            }




            string sql = sb.ToString();
            return sql;
        }
        public string ApplyJoinQuary(string baseTable, string baseAlias, List<string> selectFields,
            List<(string JoinType, string Table, string Alias, string Condition)> joins, SqlQueryOptions queryOptions)
        {
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
                sb.AppendLine($"ORDER BY {baseAlias}.Id ASC");
                hasOrder = true;
            }




            string sql = sb.ToString();
            return sql;
        }

        //public string ApplyJoinQuary(
        //    string baseTable,
        //    string baseAlias,
        //    List<string> selectFields,
        //    List<(string JoinType, string Table, string Alias, string Condition)> joins,
        //    SqlQueryOptions queryOptions,
        //    string? whereClause = null
        //)
        //{
        //    var sb = new StringBuilder();

        //    sb.AppendLine($"SELECT {string.Join(", ", selectFields)}");
        //    sb.AppendLine($"FROM {baseTable} {baseAlias}");

        //    foreach (var join in joins)
        //        sb.AppendLine($"{join.JoinType} {join.Table} ON {join.Condition}");

        //    // WHERE clause
        //    if (!string.IsNullOrWhiteSpace(whereClause))
        //        sb.AppendLine(whereClause);

        //    if (queryOptions?.Sorts != null && queryOptions.Sorts.Any())
        //    {
        //        var orders = queryOptions.Sorts
        //            .Select(s => $"{s.FieldName} {(s.IsAscending.HasValue && s.IsAscending.Value ? "ASC" : "DESC")}");
        //        sb.AppendLine("ORDER BY " + string.Join(", ", orders));
        //    }
        //    else
        //    {
        //        sb.AppendLine($"ORDER BY {baseAlias}.Id ASC");
        //    }

        //    return sb.ToString();
        //}


        public IEnumerable<TResult> ApplyFilters<TResult>(IEnumerable<TResult> source, SqlQueryOptions queryOptions)
        {
            var filters = queryOptions.Filters;
            if (filters == null || filters.Count == 0)
                return source.Skip(queryOptions.Skip).Take(queryOptions.Take ?? 2000000000);

            var query = source.AsQueryable();

            foreach (var filter in filters.ToList()) // Clone list to avoid modification issues while iterating
            {
                var finilfilter = filter;
                // If filter is a serialized stringified array, deserialize it
                if (filter.Length == 1 && filter[0].StartsWith("["))
                {
                    try
                    {
                        // Deserialize the stringified array into an actual string[]
                        var deserializedFilter = JsonConvert.DeserializeObject<string[]>(filter[0]);
                        if (deserializedFilter != null)
                        {
                            // Update the filter element in the original list
                            filters[filters.IndexOf(filter)] = deserializedFilter;
                            finilfilter = deserializedFilter;
                        }
                    }
                    catch (Exception ex)
                    {
                        //return ReturnBase<IEnumerable<IncludeInspectorDto>>.Fail(ex, _exceptionManager);
                        continue;
                    }
                }

                // Proceed with processing the filter
                string property = "";
                string op = "";
                string value = "";

                if (finilfilter.Length == 3)
                {
                    property = finilfilter[0];
                    op = finilfilter[1];
                    value = finilfilter[2];
                }
                else
                {
                    continue;
                }

                // Build expression: e.g. x => x.Price < 5
                var parameter = Expression.Parameter(typeof(TResult), "x");
                var left = Expression.PropertyOrField(parameter, property);

                // Convert value type to match property type
                var propertyType = left.Type;
                var typedValue = Convert.ChangeType(value, propertyType);
                var right = Expression.Constant(typedValue, propertyType);

                Expression comparison = op switch
                {
                    "=" => Expression.Equal(left, right),
                    "!=" => Expression.NotEqual(left, right),
                    ">" => Expression.GreaterThan(left, right),
                    ">=" => Expression.GreaterThanOrEqual(left, right),
                    "<" => Expression.LessThan(left, right),
                    "<=" => Expression.LessThanOrEqual(left, right),
                    "contains" => Expression.Call(left, nameof(string.Contains), null, right),
                    _ => throw new NotSupportedException($"Operator '{op}' not supported")
                };

                var lambda = Expression.Lambda<Func<TResult, bool>>(comparison, parameter);
                query = query.Where(lambda);
            }

            query = query.Skip(queryOptions.Skip).Take(queryOptions.Take ?? 2000000000);
            return query.ToList();
        }
    }
}
