
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Items
{
    public class ItemQuery : QueryObjectBase<ItemReturnSearchDto>
    {
        public ItemQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }
        public override async Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.Item";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "Code",
                    "SKU",
                    "Name",
                    "Description",
                    "ItemGroupId",
                    "ItemType",
                    "UnitOfMeasureId",
                    "IsStocked",
                    "IsSerialTracked",
                    "IsBatchTracked",
                    "IsExpiryTracked",
                    "DefaultWarehouseId",
                    "DefaultSupplierId ",
                    "ReorderLevel",
                    "ReorderQuantity ",
                    "SafetyStock",
                    "Sale",
                    "IncludeInPOS",
                    "IncludeInOnline",
                    "ETAItemType",
                    "ETAItemCode",
                    "LeadTime",
                    "Weight",
                    "Volume",
                    "UnitPrice",
                    "BarCode",
                    "ItemPhotoId ",
                    "BrandId",
                    "ModelId",
                    "ColorId",
                    "SizeId",
                    "UnitCost ",
                    "HasVariant",
                    "RelatedItemVariantId",
                    "Disabled",
                    "SeriesId",
                    "RunningNumber",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // Joins
                var itemGroupJoin = new JoinTable("Inventory.ItemGroup", "Name ItemGroupName", "ItemGroupId Id");
                var uomJoin = new JoinTable("Inventory.UnitOfMeasure", "Code UnitOfMeasureCode, Name UnitOfMeasureName", "UnitOfMeasureId Id");
                var warehouseJoin = new JoinTable("Inventory.Warehouse", "Code DefaultWarehouseCode, Name DefaultWarehouseName", "DefaultWarehouseId Id");
                var brandJoin = new JoinTable("Inventory.Brand", "Name BrandName", "BrandId Id");
                var modelJoin = new JoinTable("Inventory.Model", "Name ModelName", "ModelId Id");
                var colorJoin = new JoinTable("Inventory.Color", "Name ColorName", "ColorId Id");
                var sizeJoin = new JoinTable("Inventory.Size", "Name SizeName", "SizeId Id");
                var supplierJoin = new JoinTable("Accounting.Supplier", "Name SupplierName, Code SupplierCode", "DefaultSupplierId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        itemGroupJoin,
                        uomJoin,
                        warehouseJoin,
                        brandJoin,
                        modelJoin,
                        colorJoin,
                        sizeJoin,
                        supplierJoin
                    }
                    ,
                   queryOptions
                );

                var queryResult = await _dapper.QueryList<ItemReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<ItemReturnSearchDto>>.Success(queryResult.Result);
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