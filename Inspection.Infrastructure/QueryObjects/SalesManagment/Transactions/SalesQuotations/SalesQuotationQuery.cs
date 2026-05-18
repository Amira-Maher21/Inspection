using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SalesManagment.Transactions.SalesQuotations
{
    public class SalesQuotationQuery : QueryObjectBase<SalesQuotationReturnSearchDto>
    {

        public SalesQuotationQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string tableName = "Sales.SalesQuotation";

                var selectFields = new List<string>
                {
                    "SQ.Id",
                    "SQ.Tenant_ID",
                    "SQ.CompanyId",
                    "SQ.QuotationNumber",
                    "SQ.CustomerId",
                    "SQ.InspectionRequestId",
                    "SQ.SalespersonId",
                    "SQ.TaxTypeId",
                    "SQ.CurrencyId",
                    "SQ.QuotationDate",
                    "SQ.VersionNumber",
                    "SQ.ValidUntil",
                    "SQ.PONumber",
                    "SQ.Discount",
                    "SQ.TotalAmount",
                    "SQ.TermsAndConditions",
                    "SQ.CustomerNote",
                    "SQ.CustomerNote",
                    "SQ.ApprovalStatus",
                    "SQ.DocumentStatusCancelled",
                    "SQ.DocumentStatusDeclined",
                    "SQ.SeriesId",
                    "SQ.RunningNumber",
                    "SQ.In_User",
                    "SQ.In_Date",
                    "SQ.Mod_User",
                    "SQ.Mod_Date",

                };


                var customerJoin = new JoinTable
                    ("Accounting.Customer",
                    "Code CustomerCode, Name CustomerName",
                    "CustomerId Id");

                var taxTypeJoin = new JoinTable
                    ("Accounting.TaxType",
                    "Code TaxTypeCode, Name TaxTypeName",
                    "TaxTypeId Id");

                var inspectionRequestJoin = new JoinTable
                    ("Inspection.InspectionRequest",
                    "RequestNumber RequestNumber",
                    "InspectionRequestId Id");

                var salespersonJoin = new JoinTable
                    ("Sales.Salesperson",
                    "Code SalespersonCode, Name SalespersonName",
                    "SalespersonId Id");

                var currencyJoin = new JoinTable
                    ("Sec.Currency",
                    "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        customerJoin,
                        taxTypeJoin,
                        inspectionRequestJoin,
                        salespersonJoin,
                        currencyJoin
                    },
                        queryOptions
                    );

                var queryResult = await _dapper.QueryList<SalesQuotationReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );


                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>.Fail(queryResult.Errors);

                if (queryOptions?.Filters == null ||
                    queryOptions.Filters.Count == 0 ||
                    queryOptions.Filters.All(f => f.All(string.IsNullOrWhiteSpace)))
                {
                    return ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>.Success(queryResult.Result ?? Enumerable.Empty<SalesQuotationReturnSearchDto>());

                }

                var list = base.ApplyFilters(queryResult.Result, queryOptions);
                return ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}