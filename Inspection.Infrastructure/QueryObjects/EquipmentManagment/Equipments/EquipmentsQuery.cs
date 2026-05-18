using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments.EquipmentNew;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.Equipments
{
    internal class EquipmentsQuery : QueryObjectBase<EquipmentReturnSearchDto>
    {
        public EquipmentsQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EquipmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.Equipment";

                string fields = @"
                    Eq.Id,
                    Eq.CompanyId,
                    Eq.EquipmentNo,
                    Eq.Description,
                    Eq.EquipmentTypeId,
                    Eq.CustomerId,
                    Eq.CustomerProjectId,
                    Eq.CustomerLocationId,
                    Eq.SerialNumber,
                    Eq.Model,
                    Eq.Manufacturer,
                    Eq.ManufactureDate,
                    Eq.OperationStartDate,
                    Eq.InstallationDate,
                    Eq.LastInspectionDate,
                    Eq.NextInspectionDate,
                    Eq.Capacity,
                    Eq.PowerRating,
                    Eq.Voltage,
                    Eq.Pressure,
                    Eq.Dimensions,
                    Eq.Weight,
                    Eq.Material,
                    Eq.Notes,
                    Eq.Tenant_ID,
                    Eq.In_User,
                    Eq.In_Date,
                    Eq.Mod_User,
                    Eq.Mod_Date
                ";
                var joins = new List<JoinTable>
            {
                new JoinTable(
                    "Inspection.EquipmentType",
                    "Name EquipmentTypeName, Code EquipmentTypeCode",
                    "EquipmentTypeId Id"
                ),
                new JoinTable(
                    "Accounting.Customer",
                    "Name CustomerName, Code CustomerCode",
                    "CustomerId Id"
                ),
                new JoinTable(
                    "Inspection.CustomerProject",
                    "ProjectName CustomerProjectName ,ProjectCode CustomerProjectCode",
                    "CustomerProjectId Id"
                ),
                new JoinTable(
                    "Inspection.CustomerLocation",
                    "StreetName CustomerLocationName, PostalCode  CustomerLocationCode",
                    "CustomerLocationId Id"
                )
            };

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<EquipmentReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<EquipmentReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EquipmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<EquipmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}