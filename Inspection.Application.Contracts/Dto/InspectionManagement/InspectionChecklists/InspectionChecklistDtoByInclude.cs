using Inspection.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists
{
    public class InspectionChecklistDtoByInclude
    {
        public long Id { get; set; }

        public string? ChecklistNumber { get; set; }

        public long JobOrderId { get; set; }
        public string? JobOrderNo { get; set; }


        public long? EquipmentTypeId { get; set; }
        public string EquipmentTypeName { get; set; }

        public long? CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public ICollection<InspectionChecklistMoreInformationDto> InspectionChecklistMoreInformations { get; set; }

        public long? EquipmentId { get; set; }
        public string EquipmentName { get; set; } = default!;
        public string? EquipmentSerialNumber { get; set; }
        public string? EquipmentEquipmentNo { get; set; }
        public string? EquipmentDescription { get; set; }
        public DateTime EquipmentPurchaseDate { get; set; }
        public DateTime EquipmentExpiryDate { get; set; }

        public long? CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public string? Address { get; set; }
        [MaxLength(50)]
        public string? Mobile { get; set; }
        [MaxLength(50)]
        public string? Phone { get; set; }
        [MaxLength(128)]
        public string? Email { get; set; }


        public string Tenant_ID { get; set; }


        public long? InspectionTypeId { get; set; }
        public string? InspectionTypeArabicName { get; set; }
        public string? InspectionTypeEnglishName { get; set; }

        public long? LocationId { get; set; }
        public string? LocationName { get; set; }

        public long? CustomerProjectId { get; set; }
        public string? CustomerProjectName { get; set; }

        public long? InspectorId { get; set; }
        public string? InspectorName { get; set; }

        public long? InspectionMethodId { get; set; }
        public string? InspectionMethodName { get; set; }

        public DateTime? PreviousInspectionDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? TimeSheetNo { get; set; }
        public string? StickerNo { get; set; }
        public string? RemarksAndRecommendations { get; set; }
        public InspectionCheckListStatus? Status { get; set; }
        public string? RefferenceStandard { get; set; }
        public string? Series { get; set; }

    }
}