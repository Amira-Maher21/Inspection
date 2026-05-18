using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.ItemGroups
{
    public class ItemGroupQuery : QueryObjectBase<ItemGroupReturnSearchDto>
    {
        public ItemGroupQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.ItemGroup";

                string fields = "[Id],[Tenant_ID],[Code],[Name],[Description],[ParentGroupId],[CostingMethods]," +
                                "[IsLeaf],[IsSerialTracking],[IsBatchTracking],[IsExpiryTracking]," +
                                "[PurchaseAccountId],[PurchaseReturnAccountId],[SalesReturnAccountId]," +
                                "[GoodsReceivedNotInvoicedAccountId],[WipAccountId],[InventoryAccountId]," +
                                "[CogsAccountId],[AdjustmentAccountId],[RevenueAccountId],[SeriesId],[RunningNumber]," +
                                "[In_User],[In_Date],[Mod_User],[Mod_Date]";

                var joins = new List<JoinTable>
                {
                   

                    new JoinTable("Accounting.ChartOfAccount", "AccountCode PurchaseAccountCode, AccountName PurchaseAccountName", "PurchaseAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode PurchaseReturnAccountCode, AccountName PurchaseReturnAccountName", "PurchaseReturnAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode SalesReturnAccountCode, AccountName SalesReturnAccountName", "SalesReturnAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode GoodsReceivedNotInvoicedAccountCode, AccountName GoodsReceivedNotInvoicedAccountName", "GoodsReceivedNotInvoicedAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode WipAccountCode, AccountName WipAccountName", "WipAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode InventoryAccountCode, AccountName InventoryAccountName", "InventoryAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode CogsAccountCode, AccountName CogsAccountName", "CogsAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode AdjustmentAccountCode, AccountName AdjustmentAccountName", "AdjustmentAccountId Id"),
                    new JoinTable("Accounting.ChartOfAccount", "AccountCode RevenueAccountCode, AccountName RevenueAccountName", "RevenueAccountId Id")
                };

                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, joins, queryOptions);

                var result = await _dapper.QueryList<ItemGroupReturnSearchDto>(query.QueryString!, query.Parameters!.ToDictionary());

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}