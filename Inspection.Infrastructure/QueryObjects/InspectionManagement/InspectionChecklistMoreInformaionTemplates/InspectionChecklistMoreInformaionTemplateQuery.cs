using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionChecklistMoreInformationTemplates
{

    internal class InspectionChecklistMoreInformationTemplateQuery : QueryObjectBase<InspectionChecklistMoreInformationTemplateDtoByInclude>
    {
        public InspectionChecklistMoreInformationTemplateQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "Inspection.InspectionChecklistMoreInformationTemplate";
                string baseAlias = "R";

                var selectFields = new List<string>
            {
            "R.Id",
            "R.EquipmentTypeId",
            "L.Name as EquipmentTypeName",
            "R.Tenant_ID"

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

                var result = await _dapper.QueryList<InspectionChecklistMoreInformationTemplateDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        //try
        //{
        //    string baseTable = "InspectionChecklistMoreInformationTemplates";
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

        //    var result = await _dapper.QueryList<InspectionChecklistMoreInformationTemplateIncludeDto>(sql);

        //    if (!result.Succeeded)
        //        return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateIncludeDto>>.Fail(result.Errors);

        //    var list = base.ApplyFilters(result.Result, queryOptions);
        //    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateIncludeDto>>.Success(list);
        //}
        //catch (Exception ex)
        //{
        //    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateIncludeDto>>.Fail(ex, _exceptionManager);
        //}

        public override Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}