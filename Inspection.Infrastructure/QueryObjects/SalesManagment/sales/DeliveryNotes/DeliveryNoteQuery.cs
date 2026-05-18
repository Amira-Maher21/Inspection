using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SalesManagment.Sales.DeliveryNotes
{
    public class DeliveryNoteQuery : QueryObjectBase<DeliveryNoteReturnSearchDto>
    {
        public DeliveryNoteQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Sales.DeliveryNote";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",
                    "WarehouseId",
                    "DeliveryNoteNo",
                    "DeliveryNoteDate",

                    "CustomerId",
                    "SalesOrderId",
                    "SalesInvoiceId",

                    "CurrencyId",
                    "PaymentTermId",

                    "Posting",
                    "ApprovalStatus",

                    "TotalAmount",
                    "TaxAmount",
                    "NetAmount",

                    "ShipmentAmount",
                    "ShipmentStatus",
                    "ShipmentMethod",

                    "Notes",
                     "CustomerPurchaseOrder",
                    "CustomerPurchaseOrderDate",
                    "AdditionalDiscountType",
                    "AdditionalDiscountValue",
                    "AdditionalDiscountAmount",
                    "TotalDiscount",
                     "ShipmentAddress",
                    "DeliveryPersonName",
  
                    "SeriesId",
                    "RunningNumber",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // ================== JOINS ==================

                var salesOrderJoin = new JoinTable(
                     "Sales.SalesOrder",
                     "OrderNumber SalesOrderCode",
                     "SalesOrderId Id"
                 );

                var paymentTermJoin = new JoinTable(
                    "Accounting.PaymentTerm",
                    "Code PaymentTermCode, Name PaymentTermName",
                    "PaymentTermId Id"
                );

                var warehouseJoin = new JoinTable(
                    "Inventory.Warehouse",
                    "Code WarehouseCode, Name WarehouseName",
                    "WarehouseId Id"
                );

                var SalesInvoiceJoin = new JoinTable(
                    "Accounting.SalesInvoice",
                    "InvoiceNo SalesInvoiceCode ",
                    "SalesInvoiceId Id"
                );
                var customerJoin = new JoinTable(
                    "Accounting.Customer",
                    "Code CustomerCode, Name CustomerName",
                    "CustomerId Id"
                );
               

                var branchJoin = new JoinTable(
                    "Accounting.Branch",
                    "Code BranchCode, Name BranchName",
                    "BranchId Id"
                );

                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id"
                );


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        customerJoin,
                        branchJoin,
                        currencyJoin,
                        warehouseJoin,
                        SalesInvoiceJoin,
                        salesOrderJoin,
                        paymentTermJoin
                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<DeliveryNoteReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Fail(result.Errors);

                var data = result.Result?.ToList()
                           ?? new List<DeliveryNoteReturnSearchDto>();

                return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}