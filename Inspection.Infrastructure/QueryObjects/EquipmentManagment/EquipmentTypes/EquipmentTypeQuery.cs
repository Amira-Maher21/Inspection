using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentTypes
{
    internal class EquipmentTypeQuery : QueryObjectBase<EquipmentTypeDtoByInclude>
    {
        public EquipmentTypeQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.EquipmentType";
                string baseAlias = "EqT";

                var selectFields = new List<string>
                {
                    "EqT.Id",
                    "EqT.Name",
                    "C.Name AS EquipmentCategoryName"
                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("LEFT JOIN", "[Inspection].[EquipmentCategory] C", "C", "C.Id = EqT.EquipmentCategoryId")

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

                var result = await _dapper.QueryList<EquipmentTypeDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}