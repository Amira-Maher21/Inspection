using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
using Inspection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments
{
    public class UpdateCompanyEquipmentDto
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string SerialNumber { get; set; }
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

        public IEnumerable<EquipmentAccessoryDto>? EquipmentAccessories { get; set; }
        public IEnumerable<EquipmentSoftwareDto>? EquipmentSoftwares { get; set; }
        public IEnumerable<EquipmentCalibrationHistoryDto>? EquipmentCalibrationHistorys { get; set; }
        public IEnumerable<EquipmentPreventiveMaintenanceDto>? EquipmentPreventiveMaintenances { get; set; }
        public IEnumerable<EquipmentMaintenanceAndRepairRecordDto>? EquipmentMaintenanceAndRepairRecords { get; set; }

    }
}
