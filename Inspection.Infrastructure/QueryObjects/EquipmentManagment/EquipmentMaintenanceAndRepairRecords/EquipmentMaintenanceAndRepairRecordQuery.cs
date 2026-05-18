using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentMaintenanceAndRepairRecords
{


    internal class EquipmentMaintenanceAndRepairRecordQuery : QueryObjectBase<EquipmentMaintenanceAndRepairRecordDtoByInclude>
    {
        public EquipmentMaintenanceAndRepairRecordQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inspection.EquipmentMaintenanceAndRepairRecord";
                string fields = "[Id],[CompanyEquipmentId],[MaintenanceNo],[Dte], [DescriptionOfWorkDone],[Results],[Tenant_ID]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<EquipmentMaintenanceAndRepairRecordDtoByInclude>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }


        public override Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}