using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.Assets.Setup.FixedAssets
{
    public class FixedAssetQuery
        : QueryObjectBase<FixedAssetReturnSearchDto>
    {
        private const string TableName = "Accounting.FixedAsset";

        public FixedAssetQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>> Query(
    SqlQueryOptions queryOptions)
        {
            try
            {
                var selectFields = new[]
                {
            "Id",
            "Tenant_ID",
            "Code",
            "Name",
            "CompanyId",

            "AssetCategoryId",
            "AssetGroupId",
            "AssetLocationId",
            "AssetStatusEnum",

            "AcquisitionDate",
            "CapitalizationDate",

            "AcquisitionCost",
            "ResidualValue",
            "UsefulLifeMonths",

            "DepreciationMethod",
            "DepreciationStartDate",
            "EstimatedUnits",

            "CurrencyId",
            "SupplierId",

            "SerialNumber",
            "BarcodeValue",
            "ModelNumber",
            "Brand",

            "WarrantyStartDate",
            "WarrantyEndDate",

            "InsurancePolicyNo",
            "InsuranceStartDate",
            "InsuranceEndDate",
            "InsuranceValue",

            "CurrentCustodyEmployeeId",
            "CurrentCustodyDeptId",

            "IsCapitalized",
            "IsFullyDepreciated",
            "AccumulatedDepreciation",
            "NetBookValue",

            "Notes",

            "CostCenterId",
            "CostUnitId",
            "OperationId",
            "WBSId",
            "CostCodeId",
            "ActivityId",
            "BOQLineId",
            "SubcontractBOQId",
            "ProductionOrderId",
            "MaintenanceSupplierId",

            "SeriesId",
            "RunningNumber",

            "In_User",
            "In_Date",
            "Mod_User",
            "Mod_Date"
        };

                var joins = new List<JoinTable>
        {
            new JoinTable(
                "Accounting.AssetCategory",
                "CategoryCode AssetCategoryCode, CategoryName AssetCategoryName",
                "AssetCategoryId Id"
            ),

            new JoinTable(
                "Accounting.AssetGroup",
                "GroupCode AssetGroupCode, GroupName AssetGroupName",
                "AssetGroupId Id"
            ),

             new JoinTable(
                "Accounting.AssetLocation",
                "LocationCode AssetLocationCode, LocationName AssetLocationName",
                "AssetLocationId Id"
            ),


            new JoinTable(
                "Sec.Currency",
                "Code CurrencyCode, Name CurrencyName",
                "CurrencyId Id"
            ),

            new JoinTable(
                "Accounting.Supplier",
                "Code SupplierCode, Name SupplierName",
                "SupplierId Id"
            ),

            new JoinTable(
                "HR.Employee",
                "EmployeeCode CurrentCustodyEmployeeCode, FullName CurrentCustodyEmployeeName",
                "CurrentCustodyEmployeeId Id"
            ),

            new JoinTable(
                "HR.Department",
                "Name CurrentCustodyDeptName",
                "CurrentCustodyDeptId Id"
            ),

            new JoinTable(
                "Accounting.CostCenter",
                "Code CostCenterCode, Name CostCenterName",
                "CostCenterId Id"
            ),

            new JoinTable(
                "Accounting.CostUnit",
                "Code CostUnitCode, Name CostUnitName",
                "CostUnitId Id"
            ),

            new JoinTable(
                "Sec.Operation",
                "Code OperationCode, Name OperationName",
                "OperationId Id"
            ),

            new JoinTable(
                "Contracting.WBS",
                "WBSCode,WBSName",
                "WBSId Id"
            ),

            new JoinTable(
                "Contracting.CostCode",
                "CostCodeValue, CostCodeName",
                "CostCodeId Id"
            ),

            new JoinTable(
                "Contracting.Activity",
                " ActivityCode, ActivityName",
                "ActivityId Id"
            ),

            new JoinTable(
                "Contracting.BOQLine",
                "BOQItemCode BOQLineCode,Description BOQLineName",
                "BOQLineId Id"
            ),

            new JoinTable(
                "Contracting.SubcontractBOQ",
                "SubcontractBOQNumber SubcontractBOQCode ",
                "SubcontractBOQId Id"
            ),

            new JoinTable(
                "Manufacturing.ProductionOrder",
                "OrderNumber ProductionOrderCode",
                "ProductionOrderId Id"
            ),
             new JoinTable(
                "Accounting.Supplier",
                "Code MaintenanceSupplierCode, Name MaintenanceSupplierName",
                "MaintenanceSupplierId Id"
            ),
        };

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    TableName,
                    string.Join(", ", selectFields),
                    joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<FixedAssetReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>
                        .Fail(result.Errors);

                return ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>
                    .Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            object[] functionParameters)
            => throw new NotImplementedException();
    }
}
