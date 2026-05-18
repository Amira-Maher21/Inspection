using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using Inspection.Domain.Enums.InventoryEnums;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Items
{
    internal class ItemFilteredQuery : QueryObjectBase<ItemReturnSearchDto>
    {

        public ItemFilteredQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inventory.Item";
                string baseAlias = "Itm";

                var selectFields = new List<string>
                {
                    "Itm.Id",
                    "Itm.Tenant_ID",
                    "Itm.CompanyId",
                    "Itm.Code",
                    "Itm.SKU",
                    "Itm.Name",
                    "Itm.Description",
                    "Itm.ItemGroupId",
                    "Itm.ItemType",
                    "Itm.UnitOfMeasureId",
                    "Itm.IsStocked",
                    "Itm.IsSerialTracked",
                    "Itm.IsBatchTracked",
                    "Itm.IsExpiryTracked",
                    "Itm.DefaultWarehouseId",
                    "Itm.DefaultSupplierId",
                    "Itm.ReorderLevel",
                    "Itm.ReorderQuantity",
                    "Itm.SafetyStock",
                    "Itm.Sale",
                    "Itm.IncludeInPOS",
                    "Itm.IncludeInOnline",
                    "Itm.ETAItemType",
                    "Itm.ETAItemCode",
                    "Itm.LeadTime",
                    "Itm.Weight",
                    "Itm.Volume",
                    "Itm.UnitPrice",
                    "Itm.UnitCost",
                    "Itm.BarCode",
                    "Itm.ItemPhotoId",
                    "Itm.BrandId",
                    "Itm.ModelId",
                    "Itm.ColorId",
                    "Itm.SizeId",
                    "Itm.HasVariant",
                    "Itm.RelatedItemVariantId",
                    "Itm.Disabled",
                    "Itm.SeriesId",
                    "Itm.In_User",
                    "Itm.In_Date",
                    "Itm.Mod_User",
                    "Itm.Mod_Date",

                    "ItemGroup.Name AS GroupName"
                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
                {
                    ("LEFT JOIN", "[Inventory].[ItemGroup] ItemGroup", "ItemGroup", "ItemGroup.Id = Itm.ItemGroupId"),
                };

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var whereClause = $"WHERE {baseAlias}.ItemType = {(int)ItemType.Service}";

                if (sql.Contains("ORDER BY", StringComparison.OrdinalIgnoreCase))
                {
                    sql = sql.Replace("ORDER BY", $"{whereClause}\nORDER BY");
                }
                else
                {
                    sql += "\n" + whereClause;
                }


                var result = await _dapper.QueryList<ItemReturnSearchDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ItemReturnSearchDto>>.Fail(result.Errors);

                if (queryOptions?.Filters == null ||
                    queryOptions.Filters.Count == 0 ||
                    queryOptions.Filters.All(f => f.All(string.IsNullOrWhiteSpace)))
                {
                    return ReturnBase<IEnumerable<ItemReturnSearchDto>>.Success(result.Result ?? Enumerable.Empty<ItemReturnSearchDto>());
                }

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<ItemReturnSearchDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ItemReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}