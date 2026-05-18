using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Checklists;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists
{
    public class ChecklistSearchReturnDto
    {
        public long Id { get; set; }

        public long EquipmentId { get; set; }
        //no code here
        public string EquipmentNumber { get; set; } = string.Empty;
        public string EquipmentDescription { get; set; } = string.Empty;

        public long InspectorId { get; set; }
        public string InspectorCode { get; set; } = string.Empty;
        public string InspectorName { get; set; } = string.Empty;

        public long ChecklistTemplateId { get; set; }
        public string TemplateNumber { get; set; } = string.Empty;
        public string TemplateName { get; set; } = string.Empty;

        public long StandardId { get; set; }
        public string StandardCode { get; set; } = string.Empty;
        public string StandardName { get; set; } = string.Empty;

        public long InspectionTypeId { get; set; }
        //no code here 
        public string InspectionTypeName { get; set; } = string.Empty;
        public string InspectionTypeCode { get; set; } = string.Empty;
        public long JoborderId { get; set; }
        public string JoborderNumber { get; set; } = string.Empty;
        public DateTime JobOrderDate { get; set; }

        public long CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public EquipmentStatus Status { get; set; }
        public ChecklistDocStatus DocStatus { get; set; }

        public string Location { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }

        public long CompanyId { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string ChecklistNumber { get; set; } = string.Empty;

        public string Tenant_ID { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}