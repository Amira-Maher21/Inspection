using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentDtoByCustomerId
    {
        public long Id { get; set; }

        public string Description { get; set; }
        public string? SerialNumber { get; set; }
        public string? Notes { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public int? MaintenanceIntervalDays { get; set; }
        public bool IsCalibrated { get; set; }

        public DateTime? LastCalibrationDate { get; set; }
        public DateTime? NextCalibrationDueDate { get; set; }
        public string? EquipmentNo { get; set; }
        public string series { get; set; }
        public long EquipmentsMoreInformationId { get; set; }
        public long EquipmentTypeId { get; set; }
        public long? CustomerId { get; set; }
        public ICollection<EquipmentsMoreInformationDto> EquipmentsMoreInformations { get; set; }
        public string? Tenant_ID { get; set; }
    }
}
