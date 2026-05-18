using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SalesManagment.sales
{
    internal class JobOrderQuery : QueryObjectBase<JobOrderIncludeDto>
    {

        public JobOrderQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }


        public override async Task<ReturnBase<IEnumerable<JobOrderIncludeDto>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string tableName = "Inspection.JobOrder";
                string baseAlias = "JO";


                var selectFields = new List<string>
                {
                    // Identity
                    "JO.Id",
                    "JO.JobOrderNumber  JobOrderNumber", 
    
                    // Customer Information
                    "JO.CustomerId",
    
                    // Related Documents
                    "JO.QuotationId",
                    "JO.InspectionRequestId",
                    "JO.SalesOrderId",    
    
                    // Job Order Details
                    "JO.JobOrderDate",
                    "JO.PlannedStartDate  PlannedStartDate",
                    "JO.PlannedEndDate  PlannedEndDate",    
    
                    // Location & Site Contact
                    "JO.Location",
                    "JO.SiteContactName",
                    "JO.SiteContactMobile",
                    "JO.SiteContactEmail",
    
                    // Remarks
                    "JO.Remarks",          
    
                    // Series Information
                    "JO.SeriesId",
                    "JO.RunningNumber",     
    
                    // Status Information
                    "JO.DocumentStatus",
                    "JO.DocumentStatusCancelledDescription",
                    "JO.ApprovalStatus",               
    
                    // Audit Information
                    "JO.In_User",
                    "JO.In_Date",
                    "JO.Mod_User",
                    "JO.Mod_Date",

                };

                // ================== JOINS ==================

                var customerJoin = new JoinTable(
                    "Accounting.Customer",
                    "Name CustomerName",
                    "CustomerId Id"
                );

                var inspectionJoin = new JoinTable(
                    "Inspection.InspectionRequest",
                    "RequestNumber InspectionRequestNo",
                    "InspectionRequestId Id"
                );

                var quotationJoin = new JoinTable(
                    "Sales.SalesQuotation",
                    "QuotationNumber QuotationNo",
                    "QuotationId Id"
                );

                var salesOrderJoin = new JoinTable(
                    "Sales.SalesOrder",
                    "OrderNumber SalesOrderNo",
                    "SalesOrderId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        customerJoin,
                        inspectionJoin,
                        quotationJoin,
                        salesOrderJoin,
                    },
                    queryOptions
                );

                var jobOrderResult = await _dapper.QueryList<JobOrderIncludeDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!jobOrderResult.Succeeded)
                    return ReturnBase<IEnumerable<JobOrderIncludeDto>>.Fail(jobOrderResult.Errors);

                var jobOrderList = jobOrderResult.Result?.ToList() ?? new List<JobOrderIncludeDto>();

                if (jobOrderList.Count == 0)
                    return ReturnBase<IEnumerable<JobOrderIncludeDto>>.Success(jobOrderList);

                // Job Order Lines
                var parameters = new Dictionary<string, object>
                {
                    { "JobOrderIds", jobOrderList.Select(x => x.Id).ToArray() }
                };

                var jobOrderLinesResult = await _dapper.QueryList<JobOrderLinesDto>(
                    "SELECT * FROM [Inspection].[JobOrderLine] as master inner join [Inspection].[Inspector] as detail on master.InspectorId = detail.Id WHERE JobOrderId IN @JobOrderIds",
                    parameters
                );

                if (!jobOrderLinesResult.Succeeded)
                    return ReturnBase<IEnumerable<JobOrderIncludeDto>>.Fail(jobOrderLinesResult.Errors);

                var jobOrderLineLookup = (jobOrderLinesResult.Result ?? Enumerable.Empty<JobOrderLinesDto>())
                    .GroupBy(x => x.JobOrderId)
                    .ToDictionary(x => x.Key, x => x.ToList());

                foreach (var jobOrder in jobOrderList)
                {
                    if (jobOrderLineLookup.TryGetValue(jobOrder.Id, out var jobOrderLines))
                        jobOrder.JobOrderLines = jobOrderLines;
                }

                return ReturnBase<IEnumerable<JobOrderIncludeDto>>.Success(jobOrderList);

            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobOrderIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<JobOrderIncludeDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<JobOrderIncludeDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}