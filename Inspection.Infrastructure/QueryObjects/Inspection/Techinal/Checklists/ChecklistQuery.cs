using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inspection.Techinal.Checklists
{
    public class ChecklistQuery : QueryObjectBase<ChecklistSearchReturnDto>
    {
        public ChecklistQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }
        public override async Task<ReturnBase<IEnumerable<ChecklistSearchReturnDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.Checklist";

                string selectFields = @"
            [Id],
            [EquipmentId],
            [InspectorId],
            [ChecklistTemplateId],
            [StandardId],
            [InspectionTypeId],
            [Status],
            [Location],
            [JoborderId],
            [JobOrderLineId],
            [CustomerId],
            [Remarks],
            [InspectionDate],
            [CompanyId],
            [DocStatus],
            [SeriesId],
            [RunningNumber],
            [ChecklistNumber],
            [Tenant_ID],
            [In_User],
            [In_Date],
            [Mod_User],
            [Mod_Date]
        ";

                // Joins

                var equipmentJoin = new JoinTable(
                    "Inspection.Equipment",
                    "EquipmentNo EquipmentNumber, Description EquipmentDescription",
                    "EquipmentId Id"
                );

                var inspectorJoin = new JoinTable(
                    "Inspection.Inspector",
                    "Code InspectorCode, FirstName InspectorName",
                    "InspectorId Id"
                );

                var templateJoin = new JoinTable(
                    "Inspection.ChecklistTemplate",
                    "ChecklistTemplateNumber TemplateNumber, Name TemplateName",
                    "ChecklistTemplateId Id"
                );

                var standardJoin = new JoinTable(
                    "Inspection.InspectionStandard",
                    "Code StandardCode, Name StandardName",
                    "StandardId Id"
                );

                var inspectionTypeJoin = new JoinTable(
                    "Inspection.InspectionType",
                    "Code InspectionTypeCode, Name InspectionTypeName",
                    "InspectionTypeId Id"
                );
                var joborderJoin = new JoinTable(
                    "Inspection.JobOrder",
                    "JoborderNumber JoborderNumber, JobOrderDate JobOrderDate",
                    "JoborderId Id"
                );

                var customerJoin = new JoinTable(
                    "Accounting.Customer",
                    "Code CustomerCode, Name CustomerName",
                    "CustomerId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    selectFields,
                    new List<JoinTable>
                    {equipmentJoin,inspectorJoin,templateJoin,standardJoin,inspectionTypeJoin,joborderJoin,customerJoin},
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<ChecklistSearchReturnDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<ChecklistSearchReturnDto>>
                    .Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChecklistSearchReturnDto>>
                    .Fail(ex, _exceptionManager);
            }
        }



        public override Task<ReturnBase<IEnumerable<ChecklistSearchReturnDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ChecklistSearchReturnDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}