using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.Assets.AssetMaintenances
{
    public class AssetMaintenanceQuery : QueryObjectBase<AssetMaintenanceReturnSearchDto>
    {
        public AssetMaintenanceQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }



        public override async Task<ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.AssetMaintenance";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "BranchId",
                    "MaintenanceCode",
                    "MaintenanceType",
                    "FrequencyTypeId",
                    "FrequencyValue",
                    "MaintenanceDate",
                    "PlannedStartDate",
                    "PlannedEndDate",
                    "SupplierId",
                    "Technician",
                    "TotalEstimatedCost",
                    "TotalActualCost",
                    "InspectionRequired",
                    "InspectionResult",
                    "CertificateNumber",
                    "Description",
                    "DocumentStatus",
                    "IsApproved",
                    "SeriesId",
                    "RunningNumber",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };


                // Joins
                var branchJoin = new JoinTable
                                    ("Accounting.Branch",
                                    "Code BranchCode, Name BranchName",
                                    "BranchId Id");

                var supplierJoin = new JoinTable
                                     (
                                     "Accounting.Supplier",
                                     "Code SupplierCode, Name SupplierName",
                                     "SupplierId Id"
                                     );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                        branchJoin,
                        supplierJoin
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<AssetMaintenanceReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}