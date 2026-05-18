using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentWithChecklistTemplateDto
    {
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
        public long EquipmentTypeId { get; set; }
        public EquipmentType EquipmentTypes { get; set; }

        public Customer Customers { get; set; }
        //[ForeignKey("Customer")]
        public long? CustomerId { get; set; }

        public string? Tenant_ID { get; set; }
        public long SeriesId { get; set; } = 0;
        public List<ChecklistTemplateDto> ChecklistTemplate { get; set; } = new List<ChecklistTemplateDto>();

    }
}
