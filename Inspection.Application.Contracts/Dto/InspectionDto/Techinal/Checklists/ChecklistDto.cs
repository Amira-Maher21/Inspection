using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists.ChecklistLines;
using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Checklists;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists
{
    public class ChecklistDto
    {
        public long Id { get; set; }
        public long EquipmentId { get; set; }
        public long InspectorId { get; set; }
        public long ChecklistTemplateId { get; set; }
        public long StandardId { get; set; }
        public long InspectionTypeId { get; set; }
        public EquipmentStatus Status { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public long CompanyId { get; set; }
        public ChecklistDocStatus DocStatus { get; set; }
        public long JoborderId { get; set; }
        public long? JobOrderLineId { get; set; }
        public long CustomerId { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string ChecklistNumber { get; set; } = string.Empty;
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public EquipmentForCertificateDto Equipment { get; set; }

        public List<ChecklistLineDto> ChecklistLines { get; set; } = new List<ChecklistLineDto>();

    }
}
