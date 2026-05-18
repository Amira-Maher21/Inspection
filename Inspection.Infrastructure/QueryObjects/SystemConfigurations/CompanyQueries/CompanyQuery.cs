using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.SystemConfigurations.CompanyQueries
{
    internal class CompanyQuery : QueryObjectBase<CompanyReturnSearchDto>
    {
        public CompanyQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CompanyReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Sec.Company";

                string fields = @"
            [Id], [Name],[Code],[Address], [Tenant_ID],[PhoneNumber], [Email],[Website],
            [IndustrySector], [BuildingNumber], [Street],[Zone], [TaxIdNumber], [CommercialRegisterNumber],
            [CountryId],[CityId], [BaseCurrencyId], [OfficialCurrencyId],
            [ReportingCurrencyID],[DefaultTaxTypeId], [DefaultTaxType2Id],
            [InventoryAccountId], [CogsAccountId],[AdjustmentAccountId], [RevenueAccountId],
            [PurchaseAccountId], [PurchaseReturnAccountId],
            [GoodsReceivedNotInvoicedAccountId], [WipAccountId],
            [ActiveCostCenter], [ActiveCostUnit], [ActiveOperation], [ActiveWBS],
            [ActiveCostCode], [ActiveActivity],[ActiveBOQItem], [ActiveSubcontractBOQ],
            [CostingMethodEnum]
        ";

                // (Joins)
                // =======================

                var countryJoin = new JoinTable(
                    "Sec.Country",
                    "Code CountryCode, Name CountryName",
                    "CountryId Id"
                );

                var cityJoin = new JoinTable(
                    "Sec.City",
                    "Code CityCode, Name CityName",
                    "CityId Id"
                );

                var baseCurrencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code BaseCurrencyCode, Name BaseCurrencyName",
                    "BaseCurrencyId Id"
                );

                var officialCurrencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code OfficialCurrencyCode, Name OfficialCurrencyName",
                    "OfficialCurrencyId Id"
                );

                var reportingCurrencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code ReportingCurrencyCode, Name ReportingCurrencyName",
                    "ReportingCurrencyID Id"
                );

                var defaultTaxTypeJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode DefaultTaxTypeCode, AccountName DefaultTaxTypeName",
                    "DefaultTaxTypeId Id"
                );

                var defaultTaxType2Join = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode DefaultTaxType2Code, AccountName DefaultTaxType2Name",
                    "DefaultTaxType2Id Id"
                );

                var inventoryAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode InventoryAccountCode, AccountName InventoryAccountName",
                    "InventoryAccountId Id"
                );

                var cogsAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode CogsAccountCode, AccountName CogsAccountName",
                    "CogsAccountId Id"
                );

                var adjustmentAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode AdjustmentAccountCode, AccountName AdjustmentAccountName",
                    "AdjustmentAccountId Id"
                );

                var revenueAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode RevenueAccountCode, AccountName RevenueAccountName",
                    "RevenueAccountId Id"
                );

                var purchaseAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode PurchaseAccountCode, AccountName PurchaseAccountName",
                    "PurchaseAccountId Id"
                );

                var purchaseReturnAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode PurchaseReturnAccountCode, AccountName PurchaseReturnAccountName",
                    "PurchaseReturnAccountId Id"
                );

                var salesReturnAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode SalesReturnAccountCode, AccountName SalesReturnAccountName",
                    "SalesReturnAccountId Id"
                );

                var grniAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode GRNIAccountCode, AccountName GRNIAccountName",
                    "GoodsReceivedNotInvoicedAccountId Id"
                );

                var wipAccountJoin = new JoinTable(
                    "Accounting.ChartOfAccount",
                    "AccountCode WIPAccountCode, AccountName WIPAccountName",
                    "WipAccountId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    new List<JoinTable>
                    {
                countryJoin,
                cityJoin,
                baseCurrencyJoin,
                officialCurrencyJoin,
                reportingCurrencyJoin,

                defaultTaxTypeJoin,
                defaultTaxType2Join,

                inventoryAccountJoin,
                cogsAccountJoin,
                adjustmentAccountJoin,
                revenueAccountJoin,
                purchaseAccountJoin,
                purchaseReturnAccountJoin,
                salesReturnAccountJoin,
                grniAccountJoin,
                wipAccountJoin
                    },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<CompanyReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return queryResult;
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CompanyReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<CompanyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CompanyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}