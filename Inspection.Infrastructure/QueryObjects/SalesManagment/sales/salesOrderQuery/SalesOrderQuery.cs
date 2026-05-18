using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.salesOrderLines;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SalesManagment.sales.salesOrderQuery
{
    internal class SalesOrderQuery : QueryObjectBase<SalesOrderDtoInclude>
    {

        public SalesOrderQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }


        public override async Task<ReturnBase<IEnumerable<SalesOrderDtoInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string tableName = "Sales.SalesOrder";
                string baseAlias = "SO";


                var selectFields = new List<string>
                {
                    // Identity
                    "SO.Id",
                    "SO.Tenant_ID",
                    "SO.CompanyId",

                    // Order Info
                    "SO.OrderNumber",
                    "SO.OrderDate",

                    // References
                    "SO.CustomerId",
                    "SO.SalesQuotationId",
                    "SO.CurrencyId",
                    "SO.PaymentTermId",

                    // Dates
                    "SO.DeliveryDate",
                    "SO.ValidUntil",

                    // Financials
                    "SO.SubTotal",
                    "SO.Discount",
                    "SO.TotalAmount",

                    // Relations
                    "SO.SalespersonId",
                    "SO.BranchId",

                    // Notes
                    "SO.Notes",

                    // Status
                    "SO.DocumentStatus",
                    "SO.ApprovalStatus",
                    "SO.DocumentStatusCancelledReason",

                    // Series
                    "SO.SeriesId",
                    "SO.RunningNumber",

                    // Audit
                    "SO.In_User",
                    "SO.In_Date",
                    "SO.Mod_User",
                    "SO.Mod_Date"

                };

                // ================== JOINS ==================

                var customerJoin = new JoinTable(
                    "Accounting.Customer",
                    "Name CustomerName",
                    "CustomerId Id"
                );

                var quotationJoin = new JoinTable(
                    "Sales.SalesQuotation",
                    "QuotationNumber SalesQuotationNumber",
                    "SalesQuotationId Id"
                );

                var taxTypeJoin = new JoinTable(
                    "Accounting.TaxType",
                    "Percentage TaxTypePercentage",
                    "TaxTypeId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        customerJoin,
                        quotationJoin,
                        taxTypeJoin,
                    },
                    queryOptions
                );

                var salesOrderResult = await _dapper.QueryList<SalesOrderDtoInclude>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!salesOrderResult.Succeeded)
                    return ReturnBase<IEnumerable<SalesOrderDtoInclude>>.Fail(salesOrderResult.Errors);

                var salesOrderList = salesOrderResult.Result?.ToList()
                ?? new List<SalesOrderDtoInclude>();

                if (salesOrderList.Count == 0)
                    return ReturnBase<IEnumerable<SalesOrderDtoInclude>>.Success(salesOrderList);

                // Slaes Order Lines
                var parameters = new Dictionary<string, object>
                {
                    { "SalesOrderIds", salesOrderList.Select(x => x.Id).ToArray() }
                };

                var SalesOrderLinesResult = await _dapper.QueryList<SalesOrderLinesDto>(
                    "SELECT * FROM [Sales].[SalesOrderLine] WHERE salesOrderId IN @SalesOrderIds",
                    parameters
                );

                if (!SalesOrderLinesResult.Succeeded)
                    return ReturnBase<IEnumerable<SalesOrderDtoInclude>>.Fail(SalesOrderLinesResult.Errors);

                var SalesOrderLineLookup = (SalesOrderLinesResult.Result ?? Enumerable.Empty<SalesOrderLinesDto>())
                    .GroupBy(x => x.SalesOrderId)
                    .ToDictionary(x => x.Key, x => x.ToList());

                foreach (var salesOrder in salesOrderList)
                {
                    if (SalesOrderLineLookup.TryGetValue(salesOrder.Id, out var salesOrderLines))
                        salesOrder.SalesOrderLines = salesOrderLines;
                }

                return ReturnBase<IEnumerable<SalesOrderDtoInclude>>.Success(salesOrderList);

            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesOrderDtoInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SalesOrderDtoInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<SalesOrderDtoInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}