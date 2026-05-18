using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionChecklistMoreInformations
{
    internal class InspectionChecklistMoreInformationQuery : QueryObjectBase<InspectionChecklistMoreInformationDtoByInclude>
    {
        public InspectionChecklistMoreInformationQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "Inspection.InspectionChecklistMoreInformation";
                string baseAlias = "R";

                var selectFields = new List<string>
            {
            "R.Id",
            "R.EquipmentTypeId",
            "R.InspectionChecklistId",
            "R.Tenant_ID",
            "L.Name as EquipmentTypeName"


        };
                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("LEFT JOIN", "[Inspection].[EquipmentType] L", "L", "L.Id = R.EquipmentTypeId")

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

                var result = await _dapper.QueryList<InspectionChecklistMoreInformationDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        //try
        //{
        //    string baseTable = "InspectionChecklistMoreInformations";
        //    string baseAlias = "EqMoreInfo";

        //    var selectFields = new List<string>
        //    {
        //        "EqMoreInfo.Id",
        //        "EqMoreInfo.EquipmentTypeId",
        //        "EqMoreInfo.EquipmentTypeName"

        //        //"EqMoreInfo.EquipmentId",
        //        //"Eq.Name as EquipmentName"
        //    };

        //    var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        //    {
        //        //("LEFT JOIN", "[Equipments] Eq", "Eq", "Eq.Id = EqMoreInfo.EquipmentId"),
        //        ("LEFT JOIN", "[EquipmentType] Eqt", "Eqt", "Eqt.Id = EqMoreInfo.EquipmentTypeId")
        //    };

        //    var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

        //    var result = await _dapper.QueryList<InspectionChecklistMoreInformationIncludeDto>(sql);

        //    if (!result.Succeeded)
        //        return ReturnBase<IEnumerable<InspectionChecklistMoreInformationIncludeDto>>.Fail(result.Errors);

        //    var list = base.ApplyFilters(result.Result, queryOptions);
        //    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationIncludeDto>>.Success(list);
        //}
        //catch (Exception ex)
        //{
        //    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationIncludeDto>>.Fail(ex, _exceptionManager);
        //}

        public override Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}