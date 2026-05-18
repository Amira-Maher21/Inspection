using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inspection.Techinal.ChecklistTemplates
{
    internal class ChecklistTemplateQuery : QueryObjectBase<ChecklistTemplateSearchReturnDto>
    {
        public ChecklistTemplateQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        //public override async Task<ReturnBase<IEnumerable<ChecklistTemplateDto>>> Query(SqlQueryOptions queryOptions)
        //{
        //    try
        //    {

        //        string tableName = "Inspection.ChecklistTemplate";
        //        string fields = "[Id], [EquipmentTypeId],[Name],[StandardId],[Version], [Disabled], [CompanyId], [SeriesId], [RunningNumber], [ChecklistTemplateNumber], [Tenant_ID]";
        //        QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

        //        var result = await this._dapper.QueryList<ChecklistTemplateDto>(query.QueryString!, query.Parameters!.ToDictionary());
        //        if (!result.Succeeded)
        //            return ReturnBase<IEnumerable<ChecklistTemplateDto>>.Fail(result.Errors);

        //        return ReturnBase<IEnumerable<ChecklistTemplateDto>>.Success(result.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<ChecklistTemplateDto>>.Fail(ex, _exceptionManager);
        //    }
        //}
        public override async Task<ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>> Query(
  SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.ChecklistTemplate";
                string selectFields = "[Id], [EquipmentTypeId],[Name],[StandardId],[Version], [Disabled], [CompanyId], [SeriesId], [RunningNumber], [ChecklistTemplateNumber], [Tenant_ID]";

                // Joins
                var StandardJoin = new JoinTable("Inspection.EquipmentType", "Code EquipmentTypeCode, Name EquipmentTypeName", "EquipmentTypeId Id");
                var EquipmentTypeJoin = new JoinTable("Inspection.InspectionStandard  ", "Code StandardCode, Name StandardName", "StandardId Id");


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { StandardJoin, EquipmentTypeJoin },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<ChecklistTemplateSearchReturnDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}
