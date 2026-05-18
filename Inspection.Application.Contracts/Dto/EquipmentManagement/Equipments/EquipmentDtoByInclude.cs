using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceSchedules;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentDtoByInclude
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; }
        public string? SerialNumber { get; set; }
        public string? EquipmentNo { get; set; }

        public string? Notes { get; set; }

        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public int? MaintenanceIntervalDays { get; set; }

        public DateTime? LastCalibrationDate { get; set; }
        public DateTime? NextCalibrationDueDate { get; set; }
        public bool IsCalibrated => NextCalibrationDueDate == null || NextCalibrationDueDate > DateTime.UtcNow;

        public ICollection<MaintenanceReportDto> MaintenanceReports { get; set; }
        public ICollection<EquipmentInspectionDto> Inspections { get; set; }
        public ICollection<MaintenanceScheduleDto> Schedules { get; set; }
        public ICollection<EquipmentsMoreInformationDto> EquipmentsMoreInformations { get; set; }


        public long EquipmentTypeId { get; set; }
        public long? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? Tenant_ID { get; set; }
        public string series { get; set; }
    }
}
