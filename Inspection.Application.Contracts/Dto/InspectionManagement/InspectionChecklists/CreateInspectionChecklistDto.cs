using Inspection.Domain.Enums;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists
{
    public class CreateInspectionChecklistDto
    {
        public string? ChecklistNumber { get; set; }

        public long JobOrderId { get; set; }

        public long? CustomerId { get; set; }

        public long? EquipmentTypeId { get; set; }

        public long? EquipmentId { get; set; }

        public long? CompanyId { get; set; }
        public long? InspectionTypeId { get; set; }


        public long? LocationId { get; set; }

        public long? CustomerProjectId { get; set; }

        public long? InspectorId { get; set; }

        public long? InspectionMethodId { get; set; }


        public DateTime? PreviousInspectionDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? TimeSheetNo { get; set; }
        public string? StickerNo { get; set; }
        public string? RemarksAndRecommendations { get; set; }
        public InspectionCheckListStatus? Status { get; set; }
        public string? RefferenceStandard { get; set; }
        public string? Series { get; set; }
        public ICollection<InspectionChecklistMoreInformationDto> InspectionChecklistMoreInformations { get; set; }

        public string Tenant_ID { get; set; }
    }
}
