using Inspection.Domain.Enums;
using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Domain.Models.EquipmentManagement.EquipmentSoftwares;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.EquipmentManagement.CompanyEquipments
{
    public class CompanyEquipment : IRootEntity, ITenantEntity
    {

        public long Id { get; set; }

        public string Description { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string? Model { get; set; }
        public string? EquipmentIdNo { get; set; }
        public string? EquipmentLocation { get; set; }
        public CalibrationStatus CalibrationStatus { get; set; }
        public DateTime? CalibrationDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string? Manufacturer { get; set; }
        public string? StorageConditionTemperature { get; set; }
        public string? InternalOperationTemperature { get; set; }
        public string? StorageConditionRelativeHumidity { get; set; }
        public string? InternalOperationRelativeHumidity { get; set; }



        public string Tenant_ID { get; set; }
        public IEnumerable<EquipmentAccessory>? EquipmentAccessories { get; set; }
        public IEnumerable<EquipmentSoftware>? EquipmentSoftwares { get; set; }
        public IEnumerable<EquipmentCalibrationHistory>? EquipmentCalibrationHistorys { get; set; }
        public IEnumerable<EquipmentPreventiveMaintenance>? EquipmentPreventiveMaintenances { get; set; }
        public IEnumerable<EquipmentMaintenanceAndRepairRecord>? EquipmentMaintenanceAndRepairRecords { get; set; }


    }
}
