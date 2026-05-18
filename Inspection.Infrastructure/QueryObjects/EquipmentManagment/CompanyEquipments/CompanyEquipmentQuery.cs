using Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.CompanyEquipments
{



    internal class CompanyEquipmentQuery : QueryObjectBase<CompanyEquipmentDtoByInclude>
    {
        public CompanyEquipmentQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }



        public override async Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.CompanyEquipment";
                string baseAlias = "CE";

                var selectFields = new List<string>
            {
            "CE.Id",
            "CE.Description",
            "CE.SerialNumber",
            "CE.Notes",
            "CE.Model",
            "CE.EquipmentIdNo",
            "CE.EquipmentLocation",
            "CE.CalibrationStatus",
            "CE.CalibrationDate",
            "CE.Manufacturer",
            "CE.StorageConditionTemperature",
            "CE.InternalOperationTemperature",
            "CE.StorageConditionRelativeHumidity",
            "CE.InternalOperationRelativeHumidity",
            "CE.Tenant_ID",

                    "Acc.Id AS EquipmentAccessory_Id",
                    "Acc.CompanyEquipmentId AS EquipmentAccessory_CompanyEquipmentId",
                    "Acc.Note AS EquipmentAccessory_Note",
                    "Acc.Description AS EquipmentAccessory_Description",
                    "Acc.Model AS EquipmentAccessory_Model",
                    "Acc.SerialNumber AS EquipmentAccessory_SerialNumber",
                    "Acc.Status AS EquipmentAccessory_Status",
                    "Acc.Tenant_ID AS EquipmentAccessory_Tenant_ID",

                    "SOF.Id AS EquipmentSoftware_Id",
                    "SOF.CompanyEquipmentId AS EquipmentSoftware_CompanyEquipmentId",
                    "SOF.Description AS EquipmentSoftware_Description",
                    "SOF.Manufacturer AS EquipmentSoftware_Manufacturer",
                    "SOF.Version AS EquipmentSoftware_Version",
                    "SOF.Notes AS EquipmentSoftware_Notes",
                    "SOF.Tenant_ID AS EquipmentSoftware_Tenant_ID",

                    "CalHist.Id AS EquipmentCalibrationHistory_Id",
                    "CalHist.CompanyEquipmentId AS EquipmentCalibrationHistory_CompanyEquipmentId",
                    "CalHist.Note AS EquipmentCalibrationHistory_Note",
                    "CalHist.CertificateNo AS EquipmentCalibrationHistory_CertificateNo",
                    "CalHist.CalibrationBody AS EquipmentCalibrationHistory_CalibrationBody",
                    "CalHist.CalDate AS EquipmentCalibrationHistory_CalDate",
                    "CalHist.ExpiryDate AS EquipmentCalibrationHistory_ExpiryDate",
                    "CalHist.Tenant_ID AS EquipmentCalibrationHistory_Tenant_ID",


                    "EP.Id AS EquipmentPreventiveMaintenance_Id",
                    "EP.CompanyEquipmentId AS EquipmentPreventiveMaintenance_CompanyEquipmentId",
                    "EP.Action AS EquipmentPreventiveMaintenance_Action",
                    "EP.Frequency AS EquipmentPreventiveMaintenance_Frequency",
                    "EP.Dte AS EquipmentPreventiveMaintenance_Dte",
                    "EP.PerformedBy AS EquipmentPreventiveMaintenance_PerformedBy",
                    "EP.Note AS EquipmentPreventiveMaintenance_Note",
                    "EP.Tenant_ID AS EquipmentPreventiveMaintenance_Tenant_ID",

                    "mr.Id AS EquipmentMaintenanceAndRepairRecord_Id",
                    "mr.CompanyEquipmentId AS EquipmentMaintenanceAndRepairRecord_CompanyEquipmentId",
                    "mr.MaintenanceNo AS EquipmentMaintenanceAndRepairRecord_MaintenanceNo",
                    "mr.Dte AS EquipmentMaintenanceAndRepairRecord_Dte",
                    "mr.DescriptionOfWorkDone As EquipmentMaintenanceAndRepairRecord_DescriptionOfWorkDone",
                    "mr.Results AS EquipmentMaintenanceAndRepairRecord_Results",
                    "mr.Tenant_ID AS EquipmentMaintenanceAndRepairRecord_Tenant_ID"

        };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("LEFT JOIN", "[Inspection].[EquipmentAccessory] Acc", "Acc", "Acc.CompanyEquipmentId = CE.Id"),
            ("LEFT JOIN", "[Inspection].[EquipmentSoftware] SOF", "SOF",  "SOF.CompanyEquipmentId = CE.Id"),
            ("LEFT JOIN", "[Inspection].[EquipmentCalibrationHistory] CalHist", "CalHist", "CalHist.CompanyEquipmentId = CE.Id"),
            ("LEFT JOIN", "[Inspection].[EquipmentPreventiveMaintenance] EP", "EP", "EP.CompanyEquipmentId = CE.Id"),
            ("LEFT JOIN", "[Inspection].[EquipmentMaintenanceAndRepairRecord] mr", "mr", "mr.CompanyEquipmentId = CE.Id")
        };

                var sb = new StringBuilder();
                sb.AppendLine($"SELECT {string.Join(", ", selectFields)}");
                sb.AppendLine($"FROM {baseTable} {baseAlias}");

                foreach (var join in joins)
                    sb.AppendLine($"{join.JoinType} {join.Table} ON {join.Condition}");

                bool hasOrder = false;
                if (queryOptions?.Sorts != null && queryOptions.Sorts.Any())
                {
                    var orders = queryOptions.Sorts
                        .Select(s => $"{s.FieldName} {(s.IsAscending.HasValue && s.IsAscending.Value ? "ASC" : "DESC")}");
                    sb.AppendLine("ORDER BY " + string.Join(", ", orders));
                    hasOrder = true;
                }
                else
                {
                    sb.AppendLine($"ORDER BY {baseAlias}.Id DESC");
                    hasOrder = true;
                }

                string sql = sb.ToString();

                var result = await _dapper.QueryList<CompanyEquipmentDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}